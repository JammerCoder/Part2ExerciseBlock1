using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BookInfoCompanion
{
    public class Books : Dictionary<int, Book>
    {
        private decimal _TotalPrice;
        private decimal _AveragePrice;
        public decimal TotalPrice
        {
            get
            {
                return (_TotalPrice);
            }

            set
            {
                _TotalPrice = value;
            }
        }

        public decimal AveragePrice
        {
            get
            {
                return (_AveragePrice);
            }

            set
            {
                _AveragePrice = value;
            }
        }

        public Books()
        {

        }

        //Fetch All Books
        public Books(string sCnxn, string sLogPath)
        {
            try
            {
                #region Code Block Can be Refactored
                //Instantiating new connection object
                SqlConnection oCnxn = new SqlConnection(sCnxn);

                //Instantiating Sql Command Object 
                //Requires the Connection Information above and CommandText
                SqlCommand oCmd = new SqlCommand();
                oCmd.Connection = oCnxn;
                oCmd.CommandText = "spBookInfoFetchAll";
                #endregion

                TotalPrice = 0;
                int iRecCount = 0;

                oCnxn.Open();
                SqlDataReader oReader = oCmd.ExecuteReader();

                while (oReader.Read())
                {
                    Book oNewBook = new Book();
                    oNewBook.BookTitle = oReader["BookTitle"].ToString();
                    oNewBook.AuthorName = oReader["AuthorName"].ToString();
                    oNewBook.Length = Convert.ToInt32(oReader["Length"]);
                    oNewBook.IsOnAmazon = Convert.ToBoolean(oReader["IsOnAmazon"]);
                    oNewBook.BookID = Convert.ToInt32(oReader["BookID"]);
                    oNewBook.DateCreated = oReader["DateCreated"].ToString();
                    oNewBook.SellingPrice = Convert.ToDecimal(oReader["SellingPrice"]);

                    if (!this.ContainsKey(oNewBook.BookID))
                        this.Add(oNewBook.BookID, oNewBook); //Add to the Dictionary 

                    TotalPrice += oNewBook.SellingPrice;
                    iRecCount++;
                }

                AveragePrice = TotalPrice / iRecCount ;

                oCnxn.Close();
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("BooksFetchAll", ex.Message, sLogPath);
            }
        }

        //Ex.12.b Fetch ONE book record by ID
        public Books(string sCnxn, int iBookID, string sLogPath)  
        {
            try
            {
                #region Code Block Can be Refactored
                //Instantiating new connection object
                SqlConnection oCnxn = new SqlConnection(sCnxn);

                //Instantiating Sql Command Object 
                //Requires the Connection Information above and CommandText
                SqlCommand oCmd = new SqlCommand();
                oCmd.Connection = oCnxn;
                oCmd.CommandText = "spBookInfoSearchByBookID @BookID";
                oCmd.Parameters.AddWithValue("@BookID", iBookID);
                #endregion

                TotalPrice = 0;
                int iRecCount = 0 ;

                oCnxn.Open();
                SqlDataReader oReader = oCmd.ExecuteReader();
                
                while (oReader.Read())
                {
                    Book oNewBook = new Book();
                    oNewBook.BookTitle = oReader["BookTitle"].ToString();
                    oNewBook.AuthorName = oReader["AuthorName"].ToString();
                    oNewBook.Length = Convert.ToInt32(oReader["Length"]);
                    oNewBook.IsOnAmazon = Convert.ToBoolean(oReader["IsOnAmazon"]);
                    oNewBook.BookID = Convert.ToInt32(oReader["BookID"]);                    
                    oNewBook.DateCreated = oReader["DateCreated"].ToString();
                    oNewBook.SellingPrice = Convert.ToDecimal(oReader["SellingPrice"]);

                    if (!this.ContainsKey(oNewBook.BookID))
                        this.Add(oNewBook.BookID, oNewBook);

                    TotalPrice += oNewBook.SellingPrice;
                    iRecCount++;
                }

                AveragePrice = TotalPrice / iRecCount;

                oCnxn.Close();
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("BooksSearchByIDConstructor", ex.Message, sLogPath);
            }
        }

        //Exercise 16
        public Books(string sCnxn, string sBookTitleSearch, string sLogPath)
        {
            try
            {
                #region Code Block Can be Refactored
                //Instantiating new connection object
                SqlConnection oCnxn = new SqlConnection(sCnxn);

                //Instantiating Sql Command Object 
                //Requires the Connection Information above and CommandText
                SqlCommand oCmd = new SqlCommand();
                oCmd.Connection = oCnxn;
                oCmd.CommandText = "spBookInfoSearchOnBookTitle @BookTitle";
                oCmd.Parameters.AddWithValue("@BookTitle", sBookTitleSearch);
                #endregion

                TotalPrice = 0;
                int iRecCount = 0;

                oCnxn.Open();
                SqlDataReader oReader = oCmd.ExecuteReader();

                while (oReader.Read())
                {
                    Book oNewBook = new Book();
                    oNewBook.BookTitle = oReader["BookTitle"].ToString();
                    oNewBook.AuthorName = oReader["AuthorName"].ToString();
                    oNewBook.Length = Convert.ToInt32(oReader["Length"]);
                    oNewBook.IsOnAmazon = Convert.ToBoolean(oReader["IsOnAmazon"]);
                    oNewBook.BookID = Convert.ToInt32(oReader["BookID"]);
                    oNewBook.DateCreated = oReader["DateCreated"].ToString();
                    oNewBook.SellingPrice = Convert.ToDecimal(oReader["SellingPrice"]);

                    if (!this.ContainsKey(oNewBook.BookID))
                        this.Add(oNewBook.BookID, oNewBook);

                    TotalPrice += oNewBook.SellingPrice;
                    iRecCount++;
                }

                AveragePrice = TotalPrice / iRecCount ;

                oCnxn.Close();

                
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("BooksSearchByTitleConstructor", ex.Message, sLogPath);
            }
        }

                       
        //Fetch All Books - returned in a DataTable 
        public DataTable BooksList(string sCnxn, string sLogPath)
        {
            try
            {
                List<Book> oBooks = new List<Book>();
                Dictionary<int, Book> oBooksNew = new Dictionary<int, Book>();

                #region Code Block Can be Refactored
                /*Moved from BookList*/
                //Instantiating new connection object
                SqlConnection oCnxn = new SqlConnection(sCnxn);

                //Instantiating Sql Command Object 
                //Requires the Connection Information above and CommandText
                SqlCommand oCmd = new SqlCommand();
                oCmd.Connection = oCnxn;
                oCmd.CommandText = "spBookInfoFetchAll";
                #endregion

                //Instantiating new DataTable
                DataTable dtBookInfo = new DataTable();
                //Instantiating new SqlDataAdapter
                SqlDataAdapter daBookInfo = new SqlDataAdapter();
                daBookInfo.SelectCommand = oCmd;

                //Connection Gate
                oCnxn.Open();
                daBookInfo.SelectCommand.ExecuteNonQuery();
                daBookInfo.Fill(dtBookInfo);
                oCnxn.Close();

                return (dtBookInfo);
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("BookListing", ex.Message, sLogPath);
                return (null);
            }
        }
                
    }

    public class Book
    {
        #region Properties

        private int _BookID;
        private string _BookTitle;
        private string _AuthorName;
        private int _Length;
        private bool _IsOnAmazon; 
        private string _DateCreated;        
        private decimal _SellingPrice;
                
        public int BookID
        {
            get
            {
                return (_BookID);
            }
            set
            {
                _BookID = value;
            }
        }

        public string BookTitle
        {
            get
            {
                return (_BookTitle);
            }
            set
            {
                _BookTitle = value;
            }
        }

        public string AuthorName
        {
            get
            {
                return (_AuthorName);
            }
            set
            {
                _AuthorName = value;
            }
        }

        public int Length
        {
            get
            {
                return (_Length);
            }
            set
            {
                _Length = value;
            }
        }

        public bool IsOnAmazon
        {
            get
            {
                return (_IsOnAmazon);
            }
            set
            {
                _IsOnAmazon = value;
            }
        }

        public string DateCreated
        {
            get
            {
                return (_DateCreated);
            }
            set
            {
                _DateCreated = value;
            }
        }

        public decimal SellingPrice
        {
            get
            {
                return (_SellingPrice);
            }
            set
            {
                _SellingPrice = value;
            }
        }
        
        #endregion Properties

        public Book()
        {

        }

        //Ex.12.c Save Function to save all properties of the object
        public string Save(string sCnxn, string sLogPath)
        {      
            try
            {
                #region Code Block Can be Refactored
                //Instantiating new connection object
                SqlConnection oCnxn = new SqlConnection(sCnxn);

                //Instantiating Sql Command Object 
                //Requires the Connection Information above and CommandText
                SqlCommand oCmd = new SqlCommand();
                oCmd.Connection = oCnxn;
                #endregion

                oCmd.CommandText = "spBookInfoSave";
                oCmd.Parameters.AddWithValue("@BookID", BookID);
                oCmd.Parameters.AddWithValue("@BookTitle", BookTitle);
                oCmd.Parameters.AddWithValue("@AuthorName", AuthorName);
                oCmd.Parameters.AddWithValue("@Length", Length);
                oCmd.Parameters.AddWithValue("@IsOnAmazon", IsOnAmazon);
                oCmd.Parameters.AddWithValue("@SellingPrice", SellingPrice);

                oCnxn.Open();
                oCmd.ExecuteNonQuery();                
                oCnxn.Close();
                                
                /*string sReturnMessage = "<b>Book ID: </b>" + BookID + "<br />" +
                    "<b>Book Title: </b>" + BookTitle + "<br />" +
                    "<b>Author's Name: </b>" + AuthorName + "<br />" +
                    "<b>Length: </b>" + Length + "<br />" + 
                    "<b>Date Created: </b>" + DateCreated + "<br />";


                if (IsOnAmazon)
                    sReturnMessage += "<b>Remarks: </b> The Book is on Amazon <br />";
                else
                    sReturnMessage += "<b>Remarks: </b> The Book is not on Amazon <br />";
                */

                return "Record Successfully Saved!";

            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("BookSavingConstructor", ex.Message, sLogPath);
                return "Record not saved!";
            }
        }
    }
}
