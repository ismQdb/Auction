using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class AuctionItemsCollection : ObservableCollection<User> {
        public static int ID_Counter = GetAllAuctionItems().Count;
        public static List<AuctionItem> GetAllAuctionItems() {
            List<AuctionItem> items = new List<AuctionItem>();
            AuctionItem auctionItem;

            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT AuctionItemID, AuctionItemName, AuctionItemPrice, AuctionItemLastBidder from dbo.[AuctionItem]", connection);

                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {

                        auctionItem = new AuctionItem((int)reader["AuctionItemID"], (string)reader["AuctionItemName"], (int)reader["AuctionItemPrice"], (string)reader["AuctionItemLastBidder"]);
                        items.Add(auctionItem);
                    }
                }
            }
            return items;
        }

        public static int GetCurrentPrice(AuctionItem auctionItem) {
            int currentPrice = 0;
            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand
                    ("SELECT AuctionItemPrice FROM dbo.[AuctionItem] WHERE AuctionItemID=@ItemID", connection);

                SqlParameter itemIdParameter = new SqlParameter("@ItemID", System.Data.SqlDbType.Int);
                itemIdParameter.Value = auctionItem.AuctionItemID;

                command.Parameters.Add(itemIdParameter);

                using(SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        currentPrice = (int)reader["AuctionItemPrice"];
                    }
                }
            }
            return currentPrice;
        }

        public static void IncrementPrice(AuctionItem auctionItem) { 
            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand
                    ("UPDATE dbo.[AuctionItem] SET AuctionItemPrice=@ItemPrice+1," +
                    "AuctionItemLastBidder = @LastBidder WHERE AuctionItemID=@ItemID", connection);

                SqlParameter itemPriceParameter = new SqlParameter("@ItemPrice", System.Data.SqlDbType.Int);
                itemPriceParameter.Value = GetCurrentPrice(auctionItem);

                SqlParameter itemIdParameter = new SqlParameter("@ItemID", System.Data.SqlDbType.Int);
                itemIdParameter.Value = auctionItem.AuctionItemID;

                SqlParameter lastBidderParameter = new SqlParameter("@LastBidder", System.Data.SqlDbType.NVarChar);
                lastBidderParameter.Value = Auction._Instance.CurrentItemLastBidder.UserName;

                command.Parameters.Add(itemPriceParameter);
                command.Parameters.Add(itemIdParameter);
                command.Parameters.Add(lastBidderParameter);

                command.ExecuteNonQuery();
            }
        }

        public static void AddNewItem(AuctionItem auctionItem) {
            using(SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
                connection.Open();

                //SqlCommand command = new SqlCommand("INSERT into dbo.[AuctionItem](AuctionItemID, AuctionItemName, AuctionItemPrice, AuctionItemLastBidder)" +
                //    " VALUES(@ID, @ItemName, @ItemPrice, @LastBidder", connection);

                /*SqlCommand command = new SqlCommand
                    ("SET IDENTITY_INSERT dbo.[AuctionItem] ON; " +
                    "INSERT into dbo.[AuctionItem](AuctionItemID, AuctionItemName, AuctionItemPrice)" +
                    " VALUES(@ID, @ItemName, @ItemPrice); " +
                    "SET IDENTITY_INSERT dbo.[AuctionItem] OFF;", connection);*/

                SqlCommand command = new SqlCommand
                    ("INSERT into dbo.[AuctionItem](AuctionItemID, AuctionItemName, AuctionItemPrice, AuctionItemLastBidder)" +
                    " VALUES(@ID, @ItemName, @ItemPrice, @LastBidder); ", connection);

                SqlParameter idParameter = new SqlParameter("@ID", System.Data.SqlDbType.Int);
                idParameter.Value = auctionItem.AuctionItemID;
                ID_Counter++;

                SqlParameter itemNameParameter = new SqlParameter("@ItemName", System.Data.SqlDbType.NVarChar);
                itemNameParameter.Value = auctionItem.AuctionItemName;

                SqlParameter itemPriceParameter = new SqlParameter("@ItemPrice", System.Data.SqlDbType.Int);
                itemPriceParameter.Value = auctionItem.AuctionItemPrice;

                SqlParameter lastBidder = new SqlParameter("@LastBidder", System.Data.SqlDbType.NVarChar);
                if (auctionItem.AuctionItemLastBidder == null)
                    lastBidder.Value = "NA";
                else
                    lastBidder.Value = auctionItem.AuctionItemLastBidder;

                command.Parameters.Add(idParameter);
                command.Parameters.Add(itemNameParameter);
                command.Parameters.Add(itemPriceParameter);
                command.Parameters.Add(lastBidder);

                command.ExecuteNonQuery();
            }
        }

        public static void DeleteItem(AuctionItem auctionItem) {
            using(SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM dbo.[AuctionItem] WHERE AuctionItemID=@ItemID", connection);

                SqlParameter idParameter = new SqlParameter("@ItemID", System.Data.SqlDbType.Int);
                idParameter.Value = auctionItem.AuctionItemID;

                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();
            }
        }
    }
}
