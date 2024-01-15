
-- Criar o banco de dados se não existir
CREATE DATABASE IF NOT EXISTS livraria;
USE livraria;

-- Criar a tabela Produtos(Livros)
CREATE TABLE IF NOT EXISTS Produtos (
    id INT AUTO_INCREMENT NOT NULL,
    nome VARCHAR(255) NOT NULL,
    valor DECIMAL(10, 2) NOT NULL,
    imagem VARCHAR(255),
    quantidade INT NOT NULL,
    PRIMARY KEY(id)
);

select * from Produtos;

-- Criar a tabela Carrinho
CREATE TABLE IF NOT EXISTS Carrinho (
    id INT PRIMARY KEY,
    id_produto INT,
    id_compra INT,
    quantidade INT NOT NULL,
    FOREIGN KEY (id_produto) REFERENCES Produtos(id)
);

select * from Carrinho;

-- Criar a tabela Compra
CREATE TABLE IF NOT EXISTS Compra (
    id INT PRIMARY KEY,
    id_carrinho INT,
    valor_total DECIMAL(10, 2) NOT NULL,
    Status VARCHAR(50),
    Data_compra DATE,
    FOREIGN KEY (id_carrinho) REFERENCES Carrinho(id)
);

select * from Compra;

