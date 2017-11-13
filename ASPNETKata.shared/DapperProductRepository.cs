using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace ASPNETKata.Shared
{
	public class DapperProductRepository : IProductRepository
	{
		private readonly IDbConnection _connection;

		public DapperProductRepository(IDbConnection connection)
		{
			this._connection = connection;
		}

		public IEnumerable<Product> GetProducts()
		{
			return _connection.Query<Product>("SELECT * from product ORDER BY ProductID DESC");
		}

		public void DeleteProduct(int productId)
		{
			_connection.Execute("DELETE FROM Product WHERE ProductId = @id", new { id = productId });
		}

		public void UpdateProduct(Product prod)
		{
			_connection.Execute("UPDATE Product SET Name = @name WHERE ProductId = @id",
				new { id = prod.ProductId, name = prod.Name });
		}

		public void InsertProduct(Product prod)
		{
			_connection.Execute("INSERT into product (Name) values (@name)", new { name = prod.Name });
		}

		public Product GetDetails(int productId)
		{
			return _connection.Query<Product>("SELECT * FROM Product WHERE ProductID = @id", new { id = productId })
				.FirstOrDefault();
		}
		
	}
}