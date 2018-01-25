using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nameless.Libraries.DB.Mikasa;
using Nameless.Libraries.DB.Mikasa.Model;
using Nameless.Libraries.DB.Sinon.Model;
using static Nameless.Libraries.Msyu.Q.Assets.STRINGS;
namespace Nameless.Libraries.Msyu.Q.Model.DB
{
    public class Currency : DBMappedObject
    {
        /// <summary>
        /// The identifier
        /// </summary>
        public new int Id;
        /// <summary>
        /// The currency name
        /// </summary>
        public string Name;
        /// <summary>
        /// The currency symbol
        /// </summary>
        public string Symbol;
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        public Currency()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public Currency(SelectionResult[] result) : base(result)
        {
        }
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public override string TableName => "currency";
        /// <summary>
        /// Gets the primary key.
        /// </summary>
        /// <value>
        /// The primary key.
        /// </value>
        public override string PrimaryKey => "currency_id";
        /// <summary>
        /// Gets the insertion fields.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <returns>The insertion fields</returns>
        public override DBField[] GetInsertionFields(DB_Connector conn)
        {
            return new DBField[]
            {
                new DBField(conn) { ColumnName = "name", DataType = DBFieldType.STRING, Value = this.Name },
                new DBField(conn) { ColumnName = "symbol", DataType = DBFieldType.STRING, Value = this.Symbol },
            };
        }
        /// <summary>
        /// Gets the update fields.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public override DBField[] GetUpdateFields(DB_Connector conn)
        {
            throw new NotSupportedException(String.Format(ERR_NOT_SUPPORTED, CAP_UPDATE, this.TableName));
        }
        /// <summary>
        /// Updates the data.
        /// </summary>
        /// <param name="input">The input.</param>
        public override void UpdateData(KeyValuePair<string, object>[] input)
        {
            throw new NotSupportedException(String.Format(ERR_NOT_SUPPORTED, CAP_UPDATE, this.TableName));
        }
        /// <summary>
        /// Parses the object.
        /// </summary>
        /// <param name="result">The result.</param>
        protected override void ParseObject(SelectionResult[] result)
        {
            this.Id = result.GetInteger(this.PrimaryKey);
            this.Name = result.GetString("name");
            this.Symbol = result.GetString("symbol");
        }
    }
}
