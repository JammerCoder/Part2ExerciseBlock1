using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BookInfoCompanion
{
    public class Books : Dictionary<int, BookInfoCompanion.Books.Book>
    {
        public Books()
        {

        }

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

                    if (!this.ContainsKey(oNewBook.BookID))
                        this.Add(oNewBook.BookID, oNewBook);
                }
                oCnxn.Close();
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("BooksConstructor", ex.Message, sLogPath);
            }
        }

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

                    if (!this.ContainsKey(oNewBook.BookID))
                        this.Add(oNewBook.BookID, oNewBook);
                }
                oCnxn.Close();
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("BooksSearchByIDConstructor", ex.Message, sLogPath);
            }
        }

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

        public class Book
        {
            #region Properties

            private int _BookID;
            private string _BookTitle;
            private string _AuthorName;
            private int _Length;
            private bool _IsOnAmazon;
            private string _DateCreated;

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

            #endregion Properties

        }
    }
}
