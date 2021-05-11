using System;
using System.Data;
using System.Data.SqlClient;

namespace RIS.Common.UtilityClass {

	/// <summary>Generic Database Utility Helper Class.</summary>
	public class DatabaseUtility {
		private DatabaseUtility() { } // This class is non-creatable.


		/////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                   PUBLIC PROPERTIES                                         ////
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		static SqlConnection defaultConnection;
		static string defaultDatabase;
		static System.Data.CommandType defaultCommandType = System.Data.CommandType.Text;

		/// <summary>An open connection to a SQL Server database.</summary>
		/// <remarks><P>Set this property to omit passing a SqlConnection object into each query method. If this property is unset,
		/// the SqlConnection object MUST be passed into each query method.</P>
		/// <P>The SqlConnection can be either opened or closed. If the SqlConnection is closed, after the query is run, 
		/// it will be closed again.  The SqlConnection will remain open if it is open prior to the query running.</P>
		/// </remarks>
		public static SqlConnection Connection {
			get { return defaultConnection; }
			set { defaultConnection = value; }
		}

		/// <summary>Changes the default database.</summary>
		/// <remarks>Set this property to change the database from the default database specified in the SqlConnection.
		/// Set the value to null (Nothing in Visual Basic) to use the default database specified in the SqlConnection.</remarks>
		public static string DefaultDatabase {
			get { return defaultDatabase; }
			set { defaultDatabase = value; }
		}

		/// <summary>Changes the default CommandType.  Default CommandType is Text.</summary>
		/// <remarks>Set this property to change the default command type from Text to StoredProcedure or TableDirect.
		/// </remarks>
		public static System.Data.CommandType CommandType {
			get { return defaultCommandType; }
			set { defaultCommandType = value; }
		}


		/////////////////////////////////////////////////////////////////////////////////////////////////////
		////                                     PUBLIC METHODS                                          ////
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		#region - ExecuteNonQuery -
		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery("INSERT INTO Categories (CategoryName) VALUES ('New Category')");
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery("INSERT INTO Categories (CategoryName) VALUES ('New Category')")
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(string commandText) { return ExecuteNonQuery(defaultConnection, defaultDatabase, commandText, defaultCommandType, null); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery("INSERT INTO Categories (CategoryName) VALUES ('New Category')", CommandType.Text);
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery("INSERT INTO Categories (CategoryName) VALUES ('New Category')", CommandType.Text)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(string commandText, CommandType commandType) { return ExecuteNonQuery(defaultConnection, defaultDatabase, commandText, commandType, null); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery(
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)",
		///     new SqlParameter("@CategoryName", "New Category")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery( _
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", _
		///     new SqlParameter("@CategoryName", "New Category") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(string commandText, params SqlParameter[] parameters) { return ExecuteNonQuery(defaultConnection, defaultDatabase, commandText, defaultCommandType, parameters); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery(
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)",
		///     CommandType.Text,
		///     new SqlParameter("@CategoryName", "New Category")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery( _
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", _
		///     CommandType.Text, _
		///     new SqlParameter("@CategoryName", "New Category") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters) { return ExecuteNonQuery(defaultConnection, defaultDatabase, commandText, commandType, parameters); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery("Northwind", "INSERT INTO Categories (CategoryName) VALUES ('New Category')");
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery("Northwind", "INSERT INTO Categories (CategoryName) VALUES ('New Category')")
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(string database, string commandText) { return ExecuteNonQuery(defaultConnection, database, commandText, defaultCommandType, null); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery("Northwind", "INSERT INTO Categories (CategoryName) VALUES ('New Category')", CommandType.Text);
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery("Northwind", "INSERT INTO Categories (CategoryName) VALUES ('New Category')", CommandType.Text)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(string database, string commandText, CommandType commandType) { return ExecuteNonQuery(defaultConnection, database, commandText, commandType, null); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery(
		///     "Northwind",
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)",
		///     new SqlParameter("@CategoryName", "New Category")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery( _
		///     "Northwind", _
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", _
		///     new SqlParameter("@CategoryName", "New Category") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(string database, string commandText, params SqlParameter[] parameters) { return ExecuteNonQuery(defaultConnection, database, commandText, defaultCommandType, parameters); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery(
		///     "Northwind",
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)",
		///     new SqlParameter("@CategoryName", "New Category")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery( _
		///     "Northwind", _
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", _
		///     new SqlParameter("@CategoryName", "New Category") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(string database, string commandText, CommandType commandType, params SqlParameter[] parameters) { return ExecuteNonQuery(defaultConnection, database, commandText, commandType, parameters); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery(connection, "INSERT INTO Categories (CategoryName) VALUES ('New Category')");
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery(connection, "INSERT INTO Categories (CategoryName) VALUES ('New Category')")
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(SqlConnection connection, string commandText) { return ExecuteNonQuery(connection, defaultDatabase, commandText, defaultCommandType, null); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery(connection, "INSERT INTO Categories (CategoryName) VALUES ('New Category')", CommandType.Text);
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery(connection, "INSERT INTO Categories (CategoryName) VALUES ('New Category')", CommandType.Text)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(SqlConnection connection, string commandText, CommandType commandType) { return ExecuteNonQuery(connection, defaultDatabase, commandText, commandType, null); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery(
		///     connection,
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)",
		///     new SqlParameter("@CategoryName", "New Category")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery( _
		///     connection, _
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", _
		///     New SqlParameter("@CategoryName", "New Category")
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(SqlConnection connection, string commandText, params SqlParameter[] parameters) { return ExecuteNonQuery(connection, defaultDatabase, commandText, defaultCommandType, parameters); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery(
		///     connection,
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)",
		///     CommandType.Text,
		///     new SqlParameter("@CategoryName", "New Category")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery( _
		///     connection, _
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", _
		///     CommandType.Text, _
		///     New SqlParameter("@CategoryName", "New Category")
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(SqlConnection connection, string commandText, CommandType commandType, params SqlParameter[] parameters) { return ExecuteNonQuery(connection, defaultDatabase, commandText, commandType, parameters); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery(
		///     connection,
		///     "Northwind",
		///     "INSERT INTO Categories (CategoryName) VALUES ('New Category')"
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery( _
		///     connection, _
		///     "Northwind", _
		///     "INSERT INTO Categories (CategoryName) VALUES ('New Category')" _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(SqlConnection connection, string database, string commandText) { return ExecuteNonQuery(connection, database, commandText, defaultCommandType, null); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery(
		///     connection,
		///     "Northwind",
		///     "INSERT INTO Categories (CategoryName) VALUES ('New Category')"
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery( _
		///     connection, _
		///     "Northwind", _
		///     "INSERT INTO Categories (CategoryName) VALUES ('New Category')" _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(SqlConnection connection, string database, string commandText, CommandType commandType) { return ExecuteNonQuery(connection, database, commandText, commandType, null); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery(
		///     connection,
		///     "Northwind",
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)",
		///     new SqlParameter("@CategoryName", "New Category")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery( _
		///     connection, _
		///     "Northwind", _
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", _
		///     New SqlParameter("@CategoryName", "New Category")
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(SqlConnection connection, string database, string commandText, params SqlParameter[] parameters) {  return ExecuteNonQuery(connection, database, commandText, defaultCommandType, parameters); }

		/// <summary>Executes a Transact-SQL statement against the connection and returns the number of rows affected.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The number of rows affected.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using <B>ExecuteNonQuery</B>.
		/// The example is passed a string that is a Transact-SQL statement (such as UPDATE, INSERT, or DELETE) and a string to use to connect to the data source.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DatabaseUtility.ExecuteNonQuery(
		///     connection,
		///     "Northwind",
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)",
		///     CommandType.Text,
		///     new SqlParameter("@CategoryName", "New Category")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DatabaseUtility.ExecuteNonQuery( _
		///     connection, _
		///     "Northwind", _
		///     "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", _
		///     CommandType.Text, _
		///     New SqlParameter("@CategoryName", "New Category")
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static int ExecuteNonQuery(SqlConnection connection, string database, string commandText, CommandType commandType, params SqlParameter[] parameters) {
			if (connection == null) throw new Exception("Connection must be established before query can be run.");
			ConnectionState state = connection.State;
			int value = -1;

			// Build Command
			SqlCommand command = BuildCommand(commandText, connection, commandType, parameters);

			// Open the database connection if it isn't already opened
			if (state == ConnectionState.Closed) connection.Open();

			// Change Database - ONLY if 'database' is not null.
			if (database != null) connection.ChangeDatabase(database);

			// Execute Command
			value = command.ExecuteNonQuery();

			// If the database connection was closed before the method call, close it again
			if (state == ConnectionState.Closed) connection.Close();

			return value;
		}

		#endregion

		#region - ExecuteReader -
		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader("SELECT * FROM Customers");
		/// 
		/// while (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
	    /// 
	    /// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader("SELECT * FROM Customers")
		/// 
		/// While (reader.Read()) 
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End While
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(string commandText) { return ExecuteReader(defaultConnection, defaultDatabase, commandText, defaultCommandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader("SELECT * FROM Customers", CommandType.Text);
		/// 
		/// while (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader("SELECT * FROM Customers", CommandType.Text)
		/// 
		/// While (reader.Read()) 
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End While
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(string commandText, CommandType commandType) { return ExecuteReader(defaultConnection, defaultDatabase, commandText, commandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// 
		/// if (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader( _
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID", _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// 
		/// If (reader.Read()) Then
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End If
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(string commandText, params SqlParameter[] parameters) { return ExecuteReader(defaultConnection, defaultDatabase, commandText, defaultCommandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
		///     CommandType.Text,
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// 
		/// if (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader( _
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID", _
		///     CommandType.Text, _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// 
		/// If (reader.Read()) Then
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End If
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(string commandText, CommandType commandType, params SqlParameter[] parameters) { return ExecuteReader(defaultConnection, defaultDatabase, commandText, commandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader("Northwind", "SELECT * FROM Customers");
		/// 
		/// while (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader("Northwind", "SELECT * FROM Customers")
		/// 
		/// While (reader.Read()) 
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End While
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(string database, string commandText) { return ExecuteReader(defaultConnection, database, commandText, defaultCommandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader("Northwind", "SELECT * FROM Customers", CommandType.Text);
		/// 
		/// while (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader("Northwind", "SELECT * FROM Customers", CommandType.Text)
		/// 
		/// While (reader.Read()) 
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End While
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(string database, string commandText, CommandType commandType) { return ExecuteReader(defaultConnection, database, commandText, commandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(
		///     "Northwind",
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// 
		/// while (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader( _
		///     "Northwind", _
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID", _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// 
		/// While (reader.Read()) 
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End While
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(string database, string commandText, params SqlParameter[] parameters) { return ExecuteReader(defaultConnection, database, commandText, defaultCommandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(
		///     "Northwind",
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
		///     CommandType.Text,
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// 
		/// while (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader( _
		///     "Northwind", _
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID", _
		///     CommandType.Text, _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// 
		/// While (reader.Read()) 
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End While
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(string database, string commandText, CommandType commandType, params SqlParameter[] parameters) { return ExecuteReader(defaultConnection, database, commandText, commandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(connection, "SELECT * FROM Customers");
		/// 
		/// while (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(connection, "SELECT * FROM Customers")
		/// 
		/// While (reader.Read()) 
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End While
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(SqlConnection connection, string commandText) { return ExecuteReader(connection, defaultDatabase, commandText, defaultCommandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(connection, "SELECT * FROM Customers", CommandType.Text);
		/// 
		/// while (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(connection, "SELECT * FROM Customers", CommandType.Text)
		/// 
		/// While (reader.Read()) 
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End While
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(SqlConnection connection, string commandText, CommandType commandType) { return ExecuteReader(connection, defaultDatabase, commandText, commandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(
		///     connection,
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// 
		/// if (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader( _
		///     connection, _
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID", _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// 
		/// If (reader.Read()) Then
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End If
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(SqlConnection connection, string commandText, params SqlParameter[] parameters) { return ExecuteReader(connection, defaultDatabase, commandText, defaultCommandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(
		///     connection,
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
		///     CommandType.Text,
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// 
		/// if (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader( _
		///     connection, _
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID", _
		///     CommandType.Text, _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// 
		/// If (reader.Read()) Then
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End If
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(SqlConnection connection, string commandText, CommandType commandType, params SqlParameter[] parameters) { return ExecuteReader(connection, defaultDatabase, commandText, commandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(connection, "Northwind", "SELECT * FROM Customers");
		/// 
		/// while (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(connection, "Northwind", "SELECT * FROM Customers")
		/// 
		/// While (reader.Read()) 
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End While
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(SqlConnection connection, string database, string commandText) { return ExecuteReader(connection, database, commandText, defaultCommandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(connection, "Northwind", "SELECT * FROM Customers", CommandType.Text);
		/// 
		/// while (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(connection, "Northwind", "SELECT * FROM Customers", CommandType.Text)
		/// 
		/// While (reader.Read()) 
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End While
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(SqlConnection connection, string database, string commandText, CommandType commandType) { return ExecuteReader(connection, database, commandText, commandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(
		///     connection,
		///     "Northwind",
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// 
		/// if (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader( _
		///     connection, _
		///     "Northwind", _
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID", _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// 
		/// If (reader.Read()) Then
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End If
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(SqlConnection connection, string database, string commandText, params SqlParameter[] parameters) { return ExecuteReader(connection, database, commandText, defaultCommandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.SqlClient.SqlDataReader.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand, then executes it by 
		/// passing a string that is a Transact-SQL SELECT statement, and a string to use to connect to the data source.
		/// CommandBehavior is set to CloseConnection.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader(
		///     connection,
		///     "Northwind",
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
		///     CommandType.Text,
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// 
		/// if (reader.Read()) {
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"]);
		/// }
		/// 
		/// reader.Close(); // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// SqlDataReader reader = DatabaseUtility.ExecuteReader( _
		///     connection, _
		///     "Northwind", _
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID", _
		///     CommandType.Text, _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// 
		/// If (reader.Read()) Then
		///     Console.WriteLine("ExecuteReader: {0}, {1}, {2}", reader["CustomerID"], reader["CompanyName"], reader["ContactName"])
		/// End If
		/// 
		/// reader.Close() // this will close the connection (only if connection was not opened before ExecuteReader)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static SqlDataReader ExecuteReader(SqlConnection connection, string database, string commandText, CommandType commandType, params SqlParameter[] parameters) {
			if (connection == null) throw new Exception("Connection must be established before query can be run.");

			// Build Command
			SqlCommand command = BuildCommand(commandText, connection, commandType, parameters);

			// Open the database connection if it isn't already opened
			if (connection.State == ConnectionState.Closed) {
				connection.Open();

				// Change Database - ONLY if 'database' is not null.
				if (database != null) connection.ChangeDatabase(database);
				
				return command.ExecuteReader(CommandBehavior.CloseConnection);
			} else {
				// Change Database - ONLY if 'database' is not null.
				if (database != null) connection.ChangeDatabase(database);

				return command.ExecuteReader();
			}		
		}
		#endregion
		
		#region - ExecuteScalar -
		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar("SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'");
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customerName As String = DatabaseUtility.ExecuteScalar("SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'")
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(string commandText) { return ExecuteScalar(defaultConnection, defaultDatabase, commandText, defaultCommandType, null); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar("SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'", CommandType.Text);
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customerName As String = DatabaseUtility.ExecuteScalar("SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'", CommandType.Text)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(string commandText, CommandType commandType) { return ExecuteScalar(defaultConnection, defaultDatabase, commandText, commandType, null); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar(
		///     "SELECT CustomerName FROM Customers WHERE CustomerID = '@CustomerID'",
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar( _
		///     "SELECT CustomerName FROM Customers WHERE CustomerID = '@CustomerID'", _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(string commandText, params SqlParameter[] parameters) { return ExecuteScalar(defaultConnection, defaultDatabase, commandText, defaultCommandType, parameters); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar(
		///     "SELECT CustomerName FROM Customers WHERE CustomerID = '@CustomerID'",
		///     CommandType.Text,
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar( _
		///     "SELECT CustomerName FROM Customers WHERE CustomerID = '@CustomerID'", _
		///     CommandType.Text, _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters) { return ExecuteScalar(defaultConnection, defaultDatabase, commandText, commandType, parameters); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Northwind", "Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar("SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'");
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Northwind", "Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customerName As String = DatabaseUtility.ExecuteScalar("SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'")
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(string database, string commandText) { return ExecuteScalar(defaultConnection, database, commandText, defaultCommandType, null); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Northwind", "Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar("SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'", CommandType.Text);
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Northwind", "Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customerName As String = DatabaseUtility.ExecuteScalar("SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'", CommandType.Text)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(string database, string commandText, CommandType commandType) { return ExecuteScalar(defaultConnection, database, commandText, commandType, null); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar(
		///     "Northwind",
		///     "SELECT CustomerName FROM Customers WHERE CustomerID = '@CustomerID'",
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar( _
		///     "Northwind", _
		///     "SELECT CustomerName FROM Customers WHERE CustomerID = '@CustomerID'", _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(string database, string commandText, params SqlParameter[] parameters) { return ExecuteScalar(defaultConnection, database, commandText, defaultCommandType, parameters); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar(
		///     "Northwind",
		///     "SELECT CustomerName FROM Customers WHERE CustomerID = '@CustomerID'",
		///     CommandType.Text,
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar( _
		///     "Northwind", _
		///     "SELECT CustomerName FROM Customers WHERE CustomerID = '@CustomerID'", _
		///     CommandType.Text, _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(string database, string commandText, CommandType commandType, params SqlParameter[] parameters) { return ExecuteScalar(defaultConnection, database, commandText, commandType, parameters); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar(connection, "SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'");
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customerName As String = DatabaseUtility.ExecuteScalar(connection, "SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'")
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(SqlConnection connection, string commandText) { return ExecuteScalar(connection, defaultDatabase, commandText, defaultCommandType, null); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar(connection, "SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'", CommandType.Text);
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customerName As String = DatabaseUtility.ExecuteScalar(connection, "SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'", CommandType.Text)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(SqlConnection connection, string commandText, CommandType commandType) { return ExecuteScalar(connection, defaultDatabase, commandText, commandType, null); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar(
		///     connection,
		///     "SELECT CustomerName FROM Customers WHERE CustomerID = '@CustomerID'",
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar( _
		///     connection, _
		///     "SELECT CustomerName FROM Customers WHERE CustomerID = '@CustomerID'", _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(SqlConnection connection, string commandText, params SqlParameter[] parameters) { return ExecuteScalar(connection, defaultDatabase, commandText, defaultCommandType, parameters); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar(
		///     connection,
		///     "SELECT CustomerName FROM Customers WHERE CustomerID = '@CustomerID'",
		///     CommandType.Text,
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar( _
		///     connection, _
		///     "SELECT CustomerName FROM Customers WHERE CustomerID = '@CustomerID'", _
		///     CommandType.Text, _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(SqlConnection connection, string commandText, CommandType commandType, params SqlParameter[] parameters) { return ExecuteScalar(connection, defaultDatabase, commandText, commandType, parameters); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar(connection, "Northwind", "SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'");
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customerName As String = DatabaseUtility.ExecuteScalar(connection, "Northwind", "SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'")
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(SqlConnection connection, string database, string commandText) { return ExecuteScalar(connection, database, commandText, defaultCommandType, null); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar(connection, "Northwind", "SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'", CommandType.Text);
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customerName As String = DatabaseUtility.ExecuteScalar(connection, "Northwind", "SELECT CustomerName FROM Customers WHERE CustomerID = 'ALFKI'", CommandType.Text)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(SqlConnection connection, string database, string commandText, CommandType commandType) { return ExecuteScalar(connection, database, commandText, commandType, null); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar(connection, "Northwind", "SELECT CustomerName FROM Customers WHERE CustomerID = @CustomerID", new SqlParameter("@CustomerID", "ALFKI"));
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customerName As String = DatabaseUtility.ExecuteScalar(connection, "Northwind", "SELECT CustomerName FROM Customers WHERE CustomerID = @CustomerID", new SqlParameter("@CustomerID", "ALFKI"))
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(SqlConnection connection, string database, string commandText, params SqlParameter[] parameters)  { return ExecuteScalar(connection, database, commandText, defaultCommandType, parameters); }

		/// <summary>Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		/// <remarks>Use the <B>ExecuteScalar</B> method to retrieve a single value (for example, an aggregate value) from a database.
		/// This requires less code than using the ExecuteReader method, and then performing the operations necessary to
		/// generate the single value using the data returned by a SqlDataReader.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlCommand and then executes it using
		/// <B>ExecuteScalar</B>. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// string customerName = DatabaseUtility.ExecuteScalar(connection, "Northwind", "SELECT CustomerName FROM Customers WHERE CustomerID = @CustomerID", CommandType.Text, new SqlParameter("@CustomerID", "ALFKI"));
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customerName As String = DatabaseUtility.ExecuteScalar(connection, "Northwind", "SELECT CustomerName FROM Customers WHERE CustomerID = @CustomerID", CommandType.Text, new SqlParameter("@CustomerID", "ALFKI"))
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static object ExecuteScalar(SqlConnection connection, string database, string commandText, CommandType commandType, params SqlParameter[] parameters) {
			if (connection == null) throw new Exception("Connection must be established before query can be run.");
			object value = null;

			if (connection == null) throw new Exception("Connection must be established before query can be run.");
			ConnectionState state = connection.State;

			// Build Command
			SqlCommand command = BuildCommand(commandText, connection, commandType, parameters);

			// Open the database connection if it isn't already opened
			if (state == ConnectionState.Closed) connection.Open();

			// Change Database - ONLY if 'database' is not null.
			if (database != null) connection.ChangeDatabase(database);

			// Execute Command
			value = command.ExecuteScalar();

			// If the database connection was closed before the method call, close it again
			if (state == ConnectionState.Closed) connection.Close();

			return value;
		}
		#endregion

		#region - ExecuteDataTable -
		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable("SELECT * FROM Customers");
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customers As DataTable = DatabaseUtility.ExecuteDataTable("SELECT * FROM Customers")
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(string commandText) { return ExecuteDataTable(defaultConnection, defaultDatabase, commandText, defaultCommandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable("SELECT * FROM Customers", CommandType.Text);
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customers As DataTable = DatabaseUtility.ExecuteDataTable("SELECT * FROM Customers", CommandType.Text)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(string commandText, CommandType commandType) { return ExecuteDataTable(defaultConnection, defaultDatabase, commandText, commandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable(
		///     "SELECT * FROM Customers WHERE CustomerID = '@CustomerID'",
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable( _
		///     "SELECT * FROM Customers WHERE CustomerID = '@CustomerID'", _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(string database, string commandText, params SqlParameter[] parameters) { return ExecuteDataTable(defaultConnection, database, commandText, defaultCommandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable(
		///     "SELECT * FROM Customers WHERE CustomerID = '@CustomerID'",
		///     CommandType.Text,
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable( _
		///     "SELECT * FROM Customers WHERE CustomerID = '@CustomerID'", _
		///     CommandType.Text, _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(string database, string commandText, CommandType commandType, params SqlParameter[] parameters) { return ExecuteDataTable(defaultConnection, database, commandText, commandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable("Northwind", "SELECT * FROM Customers");
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customers As DataTable = DatabaseUtility.ExecuteDataTable("Northwind", "SELECT * FROM Customers")
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(string database, string commandText) { return ExecuteDataTable(defaultConnection, database, commandText, defaultCommandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable("Northwind", "SELECT * FROM Customers", CommandType.Text);
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customers As DataTable = DatabaseUtility.ExecuteDataTable("Northwind", "SELECT * FROM Customers", CommandType.Text)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(string database, string commandText, CommandType commandType) { return ExecuteDataTable(defaultConnection, database, commandText, commandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable(
		///     "Northwind", 
		///     "SELECT * FROM Customers WHERE CustomerID = '@CustomerID'",
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable( _
		///     "Northwind", _
		///     "SELECT * FROM Customers WHERE CustomerID = '@CustomerID'", _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(string commandText, params SqlParameter[] parameters) { return ExecuteDataTable(defaultConnection, defaultDatabase, commandText, defaultCommandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// DatabaseUtility.Connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable(
		///     "Northwind", 
		///     "SELECT * FROM Customers WHERE CustomerID = '@CustomerID'",
		///     CommandType.Text,
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// DatabaseUtility.Connection = New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable( _
		///     "Northwind", _
		///     "SELECT * FROM Customers WHERE CustomerID = '@CustomerID'", _
		///     CommandType.Text, _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(string commandText, CommandType commandType, params SqlParameter[] parameters) { return ExecuteDataTable(defaultConnection, defaultDatabase, commandText, commandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable(connection, "SELECT * FROM Customers");
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customers As DataTable = DatabaseUtility.ExecuteDataTable(connection, "SELECT * FROM Customers")
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(SqlConnection connection, string commandText) { return ExecuteDataTable(connection, defaultDatabase, commandText, defaultCommandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable(connection, "SELECT * FROM Customers", CommandType.Text);
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customers As DataTable = DatabaseUtility.ExecuteDataTable(connection, "SELECT * FROM Customers", CommandType.Text)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(SqlConnection connection, string commandText, CommandType commandType) { return ExecuteDataTable(connection, defaultDatabase, commandText, commandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable(
		///     connection,
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable( _
		///     connection, _
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID", _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(SqlConnection connection, string commandText, params SqlParameter[] parameters) { return ExecuteDataTable(connection, defaultDatabase, commandText, defaultCommandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable(
		///     connection,
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
		///     CommandType.Text,
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable( _
		///     connection, _
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID", _
		///     CommandType.Text, _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(SqlConnection connection, string commandText, CommandType commandType, params SqlParameter[] parameters) { return ExecuteDataTable(connection, defaultDatabase, commandText, commandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable(connection, "Northwind", "SELECT * FROM Customers");
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customers As DataTable = DatabaseUtility.ExecuteDataTable(connection, "Northwind", "SELECT * FROM Customers")
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(SqlConnection connection, string database, string commandText) { return ExecuteDataTable(connection, database, commandText, defaultCommandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable(connection, "Northwind", "SELECT * FROM Customers", CommandType.Text);
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// Dim customers As DataTable = DatabaseUtility.ExecuteDataTable(connection, "Northwind", "SELECT * FROM Customers", CommandType.Text)
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(SqlConnection connection, string database, CommandType commandType, string commandText) { return ExecuteDataTable(connection, database, commandText, commandType, null); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable(
		///     connection,
		///     "Northwind",
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable( _
		///     connection, _
		///     "Northwind", _
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID", _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(SqlConnection connection, string database, string commandText, params SqlParameter[] parameters)  { return ExecuteDataTable(connection, database, commandText, defaultCommandType, parameters); }

		/// <summary>Sends the System.Data.SqlClient.SqlCommand.CommandText to the System.Data.SqlClient.SqlCommand.Connection, and builds a System.Data.DataTable.</summary>
		/// <param name="connection"> Represents an open connection to a SQL Server database.</param>
		/// <param name="database">Changes the current database for an open System.Data.SqlClient.SqlConnection.</param>
		/// <param name="commandText">The text of the query.</param>
		/// <param name="commandType">Specifies how a command string is interpreted.</param>
		/// <param name="parameters">A list of type System.Data.SqlClient.SqlParameter that maps to the System.Data.SqlClient.SqlCommand.</param>
		/// <returns>A representation of one table of in-memory data.</returns>
		/// <remarks>Use the <B>ExecuteDataTable</B> method to retrieve a System.Data.DataTable from a database.
		/// This requires less code than using the SqlDataAdapter.Fill method, performing the operations necessary to
		/// generate the table of in-memory data returned by a SqlDataAdapter.
		/// </remarks>
		/// <example>
		/// <P><SPAN class="lang">[C#, Visual Basic]</SPAN> The following example creates a SqlDataAdapter and then executes it using
		/// the <B>Fill</B> method. The example is passed a string that is a Transact-SQL statement that returns an aggregate result.
		/// </P><P>
		/// <PRE class="syntax"><SPAN class="lang">[C#]</SPAN><code>
		/// SqlConnection connection = new SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;");
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable(
		///     connection,
		///     "Northwind",
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
		///     CommandType.Text,
		///     new SqlParameter("@CustomerID", "ALFKI")
		/// );
		/// </code><SPAN class="lang">[Visual Basic]</SPAN><code>
		/// Dim connection As New SqlConnection("Server=127.0.0.1;Database=Northwind;Uid=sa;Pwd=;")
		/// 
		/// DataTable customers = DatabaseUtility.ExecuteDataTable( _
		///     connection, _
		///     "Northwind", _
		///     "SELECT * FROM Customers WHERE CustomerID = @CustomerID", _
		///     CommandType.Text, _
		///     new SqlParameter("@CustomerID", "ALFKI") _
		/// )
		/// </code>
		/// </PRE>
		/// </P>
		/// </example>
		public static DataTable ExecuteDataTable(SqlConnection connection, string database, string commandText, CommandType commandType, params SqlParameter[] parameters) {
			if (connection == null) throw new Exception("Connection must be established before query can be run.");
			ConnectionState state = connection.State;
			DataTable value = new DataTable();

			// Build Adapter
			SqlDataAdapter adapter = new SqlDataAdapter(BuildCommand(commandText, connection, commandType, parameters));

			// Open the database connection if it isn't already opened
			if (state == ConnectionState.Closed) connection.Open();

			// Change Database - ONLY if 'database' is not null.
			if (database != null) connection.ChangeDatabase(database);

			// Fill DataTable
			adapter.Fill(value);

			// If the database connection was closed before the method call, close it again
			if (state == ConnectionState.Closed) connection.Close();

			return value;
		}
		#endregion

        public static SqlParameter checkEmpty(string name, string value)
        {
            SqlParameter parameter;

            if ((value == null)||(value.Trim() == ""))
            {
                parameter = new SqlParameter(name, DBNull.Value);
            }
            else
            {
                parameter = new SqlParameter(name, value);
            }

            return parameter;
        }


		

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		////                                     PRIVATE METHODS                                                                                                ///
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		private static SqlCommand BuildCommand(string commandText, SqlConnection connection, CommandType commandType, params SqlParameter[] parameters) {
			SqlCommand command = new SqlCommand(commandText, connection);
			command.CommandType = commandType;

			if (parameters != null) {
				foreach (SqlParameter parameter in parameters) { command.Parameters.Add(parameter); }
			}

			return command;
		}
	}
}
