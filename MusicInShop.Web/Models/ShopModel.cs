using MusicInShop.BusinessLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicInShop.Web.Models
{
    public class ShopModel : NavbarModel
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}