-- Insert Markets
INSERT INTO Markets (Id, Name, City) VALUES
(1, 'Lemar', 'Nicosia'),
(2, 'Macro', 'Nicosia'),
(3, 'Kar', 'Kyrenia'),
(4, 'Molto', 'Kyrenia'),
(5, 'Belça', 'Famagusta'),
(6, 'Kiler', 'Famagusta');

-- Insert Products
INSERT INTO Products (Id, Barcode, Name, PhotoUrl) VALUES
(1, '8692005190019', 'KOOP Süt 1L Tam Yağlı', 'https://via.placeholder.com/200?text=KOOP'),
(2, '5449000000996', 'Coca-Cola 330ML', 'https://via.placeholder.com/200?text=CocaCola'),
(3, '5449000003102', 'Fanta 330ml', 'https://via.placeholder.com/200?text=Fanta'),
(4, '8690504020509', 'Ülker Çikolatalı Gofret 36GR', 'https://via.placeholder.com/200?text=Ulker'),
(5, '8690526011073', 'Eti Tutku', 'https://via.placeholder.com/200?text=EtiTutku'),
(6, '8690526095417', 'Eti Karam Gurme 50GR', 'https://via.placeholder.com/200?text=EtiKaram'),
(7, '8690624105650', 'Filiz Spagetti Makarna 500G', 'https://via.placeholder.com/200?text=Filiz'),
(8, '8690632031231', 'Nescafe Gold 100GR', 'https://via.placeholder.com/200?text=Nescafe'),
(9, '8711000050127', 'Redbull 250ML', 'https://via.placeholder.com/200?text=Redbull'),
(10, '8694997019118', 'Icy 0.5L Su', 'https://via.placeholder.com/200?text=Icy'),
(11, '5053990127740', 'Pringles Sour Cream & Onion 165GR', 'https://via.placeholder.com/200?text=Pringles');

-- Insert MarketProducts with prices and discount prices
INSERT INTO MarketProducts (ProductId, MarketId, Price, DiscountPrice) VALUES
-- KOOP Süt
(1, 1, 25.50, 24.00),
(1, 2, 26.00, NULL),
(1, 3, 24.50, NULL),
(1, 4, 25.00, 23.50),
(1, 5, 26.50, NULL),
(1, 6, 25.50, NULL),
-- Coca-Cola
(2, 1, 12.50, 11.00),
(2, 2, 13.00, NULL),
(2, 3, 12.00, 10.50),
(2, 4, 12.75, NULL),
(2, 5, 13.50, 12.00),
(2, 6, 12.50, NULL),
-- Fanta
(3, 1, 12.50, NULL),
(3, 2, 13.00, 11.50),
(3, 3, 12.00, NULL),
(3, 4, 12.75, 11.00),
(3, 5, 13.50, NULL),
(3, 6, 12.50, 10.99),
-- Ülker Gofret
(4, 1, 18.00, 16.50),
(4, 2, 18.50, NULL),
(4, 3, 17.50, NULL),
(4, 4, 18.00, 17.00),
(4, 5, 19.00, NULL),
(4, 6, 18.00, NULL),
-- Eti Tutku
(5, 1, 15.00, NULL),
(5, 2, 15.50, 14.00),
(5, 3, 14.50, NULL),
(5, 4, 15.00, NULL),
(5, 5, 16.00, 15.00),
(5, 6, 15.00, NULL),
-- Eti Karam
(6, 1, 14.50, 13.50),
(6, 2, 15.00, NULL),
(6, 3, 14.00, NULL),
(6, 4, 14.50, 13.75),
(6, 5, 15.50, NULL),
(6, 6, 14.50, NULL),
-- Filiz Makarna
(7, 1, 22.00, NULL),
(7, 2, 22.50, 20.50),
(7, 3, 21.50, NULL),
(7, 4, 22.00, NULL),
(7, 5, 23.00, 21.00),
(7, 6, 22.00, NULL),
-- Nescafe
(8, 1, 45.00, 40.00),
(8, 2, 46.00, NULL),
(8, 3, 44.00, NULL),
(8, 4, 45.50, 42.00),
(8, 5, 47.00, NULL),
(8, 6, 45.00, NULL),
-- Redbull
(9, 1, 35.00, NULL),
(9, 2, 35.50, 33.00),
(9, 3, 34.50, NULL),
(9, 4, 35.00, NULL),
(9, 5, 36.00, 34.00),
(9, 6, 35.00, NULL),
-- Icy
(10, 1, 8.50, 7.50),
(10, 2, 9.00, NULL),
(10, 3, 8.25, NULL),
(10, 4, 8.75, 8.00),
(10, 5, 9.50, NULL),
(10, 6, 8.50, NULL),
-- Pringles
(11, 1, 28.00, NULL),
(11, 2, 28.50, 26.00),
(11, 3, 27.50, NULL),
(11, 4, 28.00, 25.50),
(11, 5, 29.00, NULL),
(11, 6, 28.00, NULL);
