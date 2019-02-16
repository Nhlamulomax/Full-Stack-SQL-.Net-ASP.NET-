using System;

namespace Question_1
{
    internal class SqlCommand
    {
        private string v;
        private SqlConnection myConnection;

        public SqlCommand(string v, SqlConnection myConnection)
        {
            this.v = v;
            this.myConnection = myConnection;
        }

        internal void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }
    }
}