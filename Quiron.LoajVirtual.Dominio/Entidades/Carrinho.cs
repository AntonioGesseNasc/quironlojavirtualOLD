﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Dominio.Entidades
{

    public class Carrinho
    {

        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();

        // Adicionar
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
            {
                _itemCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }

        // Remover
        public void RemoverItem(Produto produto)
        {
            _itemCarrinho.RemoveAll(i => i.Produto.ProdutoId == produto.ProdutoId);
        }

        // Obter o valor total
        public decimal ObterValorTotal()
        {
            return _itemCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        // Limpar Carrinho
        public void LimparCarrinho()
        {
            _itemCarrinho.Clear();
        }

        // Itens Carrinho
        public IEnumerable<ItemCarrinho> ItemCarrinho 
        {
            get { return _itemCarrinho; }
        }
    }

    public  class ItemCarrinho
	{
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

	}
    
}
