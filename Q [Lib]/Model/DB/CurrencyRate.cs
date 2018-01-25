using Nameless.Libraries.DB.Mikasa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nameless.Libraries.DB.Mikasa;

namespace Nameless.Libraries.Msyu.Q.Model.DB
{
    public class CurrencyRate : DBMappedObject
    {
        /// <summary>
        /// From currency identifier
        /// </summary>
        public int FromCurrencyId;
        /// <summary>
        /// To currency identifier
        /// </summary>
        public int ToCurrencyId;
        /// <summary>
        /// The exchange value
        /// </summary>
        public double Exchange;
        /// <summary>
        /// The echange register date
        /// </summary>
        public DateTime RegisterAt;
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRate"/> class.
        /// </summary>
        public CurrencyRate()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRate"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public CurrencyRate(SelectionResult[] result) : base(result)
        {
        }
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public override string TableName => "currency_rates";
        /// <summary>
        /// Gets the primary key.
        /// </summary>
        /// <value>
        /// The primary key.
        /// </value>
        public override string PrimaryKey => "from_currency_id";
        /// <summary>
        /// Gets the insertion fields.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <returns>The insertion fields</returns>
        public override DBField[] GetInsertionFields(DB_Connector conn)
        {
            return new DBField[]
            {
                new DBField(conn) { ColumnName = "from_currency_id", DataType = DBFieldType.NUMBER, Value = this.FromCurrencyId },
                new DBField(conn) { ColumnName = "to_currency_id", DataType = DBFieldType.NUMBER, Value = this.ToCurrencyId },
                new DBField(conn) { ColumnName = "exchange_value", DataType = DBFieldType.NUMBER, Value = this.Exchange },
                new DBField(conn) { ColumnName = "register_at", DataType = DBFieldType.DATE, Value = this.RegisterAt },
            };
        }
        /// <summary>
        /// Gets the update fields.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <returns></returns>
        public override DBField[] GetUpdateFields(DB_Connector conn)
        {
            return new DBField[]
            {
                new DBField(conn) { ColumnName = "exchange_value", DataType = DBFieldType.NUMBER, Value = this.Exchange },
                new DBField(conn) { ColumnName = "register_at", DataType = DBFieldType.DATE, Value = this.RegisterAt },
            };
        }
        /// <summary>
        /// Updates the data.
        /// </summary>
        /// <param name="input">The input.</param>
/        public override void UpdateData(KeyValuePair<string, object>[] input)
        {
            foreach (var val in input)
                switch (val.Key)
                {
                    case "exchange_value":
                        this.Exchange = (double)val.Value;
                        break;
                    case "register_at":
                        this.RegisterAt = (DateTime)val.Value;
                        break;
                }
        }
        /// <summary>
        /// Parses the object.
        /// </summary>
        /// <param name="result">The result.</param>
        protected override void ParseObject(SelectionResult[] result)
        {
            this.FromCurrencyId = result.GetInteger("from_currency_id");
            this.ToCurrencyId = result.GetInteger("to_currency_id");
            this.Exchange = result.GetValue<Double>("exchange_value");
            this.RegisterAt = result.GetValue<DateTime>("register_at");
        }
    }
}
