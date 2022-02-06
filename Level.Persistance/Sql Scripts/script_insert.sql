Use[Level]
/*
INSERT INTO Article(name,price) VALUES('water', 100.00)
INSERT INTO Article(name,price) VALUES('honey', 200.00)
INSERT INTO Article(name,price) VALUES('mango', 400.00)
INSERT INTO Article(name,price) VALUES('tea', 1000.00)
INSERT INTO Article(name,price) VALUES('ketchup', 999.00)
INSERT INTO Article(name,price) VALUES('mayonnaise', 999.00)
INSERT INTO Article(name,price) VALUES('fries', 378.00)
INSERT INTO Article(name,price) VALUES('ham', 147.00)
*/
/*
INSERT INTO Delivery(minPrice,maxPrice,price) VALUES(0,1000.00,800.00)
INSERT INTO Delivery(minPrice,maxPrice,price) VALUES(1000.00, 2000.00, 400)
INSERT INTO Delivery(minPrice,maxPrice,price) VALUES(2000.00, 0.00, 0.00)
*/
/*
 Delete Cart
*/
select * from Article
select * from Cart
select * from Delivery
select * from Discount