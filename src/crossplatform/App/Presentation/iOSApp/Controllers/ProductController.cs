using Foundation;
using System;
using UIKit;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace iOSApp
{
    public partial class ProductController : UIViewController
    {
        public ProductController (IntPtr handle) : base (handle)
        {
        }

        partial void FindButton_TouchUpInside(UIButton sender)
        {
            nameText.Text = string.Empty;
			priceText.Text = string.Empty;
			quantityText.Text = string.Empty;
			categoryText.Text = string.Empty;
            if(string.IsNullOrWhiteSpace(idText.Text)){
                productMessage.Text = "El ID es requerido";
            }else{
                productMessage.Text = string.Empty;
                idText.ResignFirstResponder();
                GetProduct(idText.Text);
            }

        }

        async void GetProduct(string productId){
			using (var client = new System.Net.Http.HttpClient())
			{
				client.BaseAddress =
					new Uri("https://ticapacitacion.com/webapi/northwind/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Notificar aqui que la API Web será invocada
				HttpResponseMessage Response = await client.GetAsync($"product/{productId}");

                var response = await Response.Content.ReadAsStringAsync();
				// Notificar aquí que se va a verificar el resultado de la llamada
				if (Response.IsSuccessStatusCode)
				{
					var product = JsonConvert.DeserializeObject<Product>(response);
					if (product != null)
					{
                        nameText.Text = product.ProductName;
                        priceText.Text = product.UnitPrice.ToString();
                        quantityText.Text = product.UnitsInStock.ToString();
                        categoryText.Text = product.CategoryID.ToString();
                        productMessage.Text = "Producto encontrado"; 
					}
					else
					{
                        productMessage.Text = "Producto no encontrado";
					}
				}
                else{
                    dynamic message = JsonConvert.DeserializeObject<Object>(response);
                    productMessage.Text = message.Message;
                }
			}
        }
    }

    class Product
    {
        public int CategoryID
        {
            get;
            set;
        }
        public bool Discontinued
        {
            get;
            set;
        }
        public int ProductID
        {
            get;
            set;
        }
        public string ProductName
        {
            get;
            set;
        }
        public string QuantityPerUnit
        {
            get;
            set;
        }
        public int ReorderLevel
        {
            get;
            set;
        }
        public int SupplierID
        {
            get;
            set;
        }
        public decimal UnitPrice
        {
            get;
            set;
        }
        public int UnitsInStock
        {
            get;
            set;
        }
		public int UnitsOnOrder
		{
			get;
			set;
		}
    }
}