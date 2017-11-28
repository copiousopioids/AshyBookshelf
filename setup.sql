DROP TABLE IF EXISTS Movies;
DROP TABLE IF EXISTS Books;
DROP TABLE IF EXISTS Cardholder_Item;
DROP TABLE IF EXISTS Item_Genre;
DROP TABLE IF EXISTS Genres;
DROP TABLE IF EXISTS Item_Condition;
DROP TABLE IF EXISTS Condit; /* apparently "Condition" is a reserved word */
DROP TABLE IF EXISTS People_Roles_Items;
DROP TABLE IF EXISTS Roles;
DROP TABLE IF EXISTS Awards_Won;
DROP TABLE IF EXISTS Fines;
DROP TABLE IF EXISTS Owes;
DROP TABLE IF EXISTS Item_People;
DROP TABLE IF EXISTS Cardholders;
DROP TABLE IF EXISTS Awards;
DROP TABLE IF EXISTS People;
DROP TABLE IF EXISTS Items;

CREATE TABLE Items(
  item_id       INT NOT NULL AUTO_INCREMENT,
  title         VARCHAR(75) NOT NULL,
  available     BIT NOT NULL,
  weekly_fine   DOUBLE NOT NULL,
  damage_fine   DOUBLE NOT NULL,
  PRIMARY KEY(item_id)
);

CREATE TABLE Movies(
  item_id       INT NOT NULL,
  description   VARCHAR(400),
  duration      DECIMAL(3,2), /* Int for minutes? */
  studio        VARCHAR(50),
  barcode_no    VARCHAR(50) NOT NULL,
  PRIMARY KEY(item_id),
  FOREIGN KEY(item_id) 
	REFERENCES Items(item_id)
	ON DELETE CASCADE
);

CREATE TABLE Books(
  item_id       INT NOT NULL,
  num_pages     INT,
  publisher     VARCHAR(50),
  isbn          VARCHAR(30) NOT NULL,
  PRIMARY KEY(item_id),
  FOREIGN KEY(item_id) 
	REFERENCES Items(item_id)
	ON DELETE CASCADE
);

CREATE TABLE Cardholders(
  c_id          INT NOT NULL AUTO_INCREMENT,
  username      VARCHAR(80) NOT NULL,
  password      VARCHAR(30) NOT NULL,
  phone         VARCHAR(30),
  name          VARCHAR(50) NOT NULL,
  address       VARCHAR(100),
  PRIMARY KEY(c_id),
  UNIQUE(username)
);

CREATE TABLE Genres(
  genre_id      INT NOT NULL,
  genre         VARCHAR(30) NOT NULL,
  PRIMARY KEY(genre_id)
);

CREATE TABLE Condit(
  code          INT NOT NULL,
  condit     VARCHAR(30),
  PRIMARY KEY(code)
);

CREATE TABLE People(
  person_id     INT NOT NULL AUTO_INCREMENT,
  first_name    VARCHAR(30) NOT NULL,
  last_name     VARCHAR(30) NOT NULL,
  birth_date    DATE NOT NULL,
  death_date    DATE,
  twitter       VARCHAR(30),
  PRIMARY KEY(person_id)
);

CREATE TABLE Roles(
  role_code     INT NOT NULL,
  role          VARCHAR(30) NOT NULL,
  PRIMARY KEY(role_code)
);

CREATE TABLE Awards(
  award_id      INT NOT NULL,
  name          VARCHAR(60) NOT NULL,
  PRIMARY KEY(award_id)
);

CREATE TABLE Fines(
  fine_id       INT NOT NULL AUTO_INCREMENT,
  amount        DOUBLE NOT NULL,
  due_date      DATE NOT NULL,
  paid          BIT NOT NULL,
  description   VARCHAR(100),
  PRIMARY KEY(fine_id)
);

CREATE TABLE Owes(
  c_id           INT NOT NULL,
  fine_id       INT NOT NULL,
  PRIMARY KEY(c_id,fine_id),
  FOREIGN KEY(c_id) 
	REFERENCES Cardholders(c_id)
	ON DELETE CASCADE,
  FOREIGN KEY(fine_id) 
	REFERENCES Fines(fine_id)
	ON DELETE CASCADE
);

CREATE TABLE Awards_Won(
  person_id       INT NOT NULL,
  award_id        INT NOT NULL,
	year_won				INT NOT NULL,
  PRIMARY KEY(person_id, award_id, year_won),
  FOREIGN KEY(person_id) 
	REFERENCES People(person_id)
	ON DELETE CASCADE,
  FOREIGN KEY(award_id) 
	REFERENCES Awards(award_id)
	ON DELETE CASCADE
);

CREATE TABLE People_Roles_Items(
  person_id       INT NOT NULL,
  role_code       INT NOT NULL,
  item_id         INT NOT NULL,
  PRIMARY KEY(person_id,role_code,item_id),
  FOREIGN KEY(person_id) 
	REFERENCES People(person_id)
	ON DELETE CASCADE,
  FOREIGN KEY(role_code) 
	REFERENCES Roles(role_code)
	ON DELETE CASCADE,
  FOREIGN KEY(item_id)
	REFERENCES Items(item_id)
	ON DELETE CASCADE
);

CREATE TABLE Item_Condition(
  item_id         INT NOT NULL,
  code            INT NOT NULL,
  PRIMARY KEY(item_id,code),
  FOREIGN KEY(item_id) 
	REFERENCES Items(item_id)
	ON DELETE CASCADE,
  FOREIGN KEY(code) 
	REFERENCES Condit(code)
	ON DELETE CASCADE
);

CREATE TABLE Item_Genre(
  item_id         INT NOT NULL,
  genre_id        INT NOT NULL,
  PRIMARY KEY(item_id,genre_id),
  FOREIGN KEY(item_id) 
	REFERENCES Items(item_id)
	ON DELETE CASCADE,
  FOREIGN KEY(genre_id) 
	REFERENCES Genres(genre_id)
	ON DELETE CASCADE
);

/* Need to decide if we are tracking history. With current setup we can't*/
CREATE TABLE Cardholder_Item(
  c_id            INT NOT NULL,
  item_id         INT NOT NULL,
  due_date        DATE NOT NULL,
  PRIMARY KEY(c_id,item_id,due_date),
  FOREIGN KEY(c_id) 
	REFERENCES Cardholders(c_id)
	ON DELETE CASCADE,
  FOREIGN KEY(item_id)
	REFERENCES Items(item_id)
	ON DELETE CASCADE
);
