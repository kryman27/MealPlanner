DROP TABLE MealNo
GO

CREATE TABLE MealNo
(
	id_meal_no INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	id_product INT NOT NULL,
	product_name VARCHAR(250) NOT NULL,
	fat FLOAT NOT NULL,
	carbs FLOAT NOT NULL,
	proteins FLOAT NOT NULL,
	energy FLOAT NOT NULL,
	products_mass FLOAT NOT NULL,
	creation_date DATE NOT NULL
)
GO
