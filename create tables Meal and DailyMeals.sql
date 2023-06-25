CREATE TABLE Meal
(
	id_meal INT PRIMARY KEY IDENTITY(1,1),
	meal_date DATE,
)

CREATE TABLE DailyMeals
(
	id_daily_meal INT PRIMARY KEY IDENTITY(1,1),
	meal_id INT FOREIGN KEY REFERENCES Meal(id_meal),
	product_id INT FOREIGN KEY REFERENCES Products(id_product),
	daily_meal_date DATE
)

