CREATE TABLE public."Users" (
	"ID" varchar(36) NOT NULL,
	"Username" varchar(256) NULL,
	"Password" varchar(12) NULL,
	"DisplayName" varchar(10) NULL,
	"Avatar" varchar(256) NULL,
	CONSTRAINT "Users_ID_PK" PRIMARY KEY ("ID")
);
CREATE TABLE public."Customer" (
    "ID" int NOT NULL,
    "Name" varchar(256) null,
    CONSTRAINT "Customer_ID_PK" PRIMARY KEY ("ID")
);

CREATE TABLE public."Product" (
    "ID" int NOT NULL,
    "Name" varchar(256) null,
    CONSTRAINT "Product_ID_PK" PRIMARY KEY ("ID")
);

CREATE TABLE public."Order" (
    "ID" int NOT NULL,
    "CustomerId" int NULL,
    "CreateDateUTC" timestamptz null,
    CONSTRAINT "Order_ID_PK" PRIMARY KEY ("ID")
);

CREATE TABLE public."OrderDetail" (
    "ID" int NOT NULL,
    "OrderId" int NULL,
    "ProductId" int NULL,
    "Quantity" int NULL,
    "UnitPrice" decimal null,
    CONSTRAINT "OrderDetail_ID_PK" PRIMARY KEY ("ID")
);

CREATE TABLE "Map" (
  "Id" SERIAL PRIMARY KEY,
  "Name" varchar,
  "BackgroundImage" varchar
);

CREATE TABLE "MapMonster" (
  "Id" SERIAL PRIMARY KEY,
  "MapId" int,
  "MonsterId" int,
  "PositionX" float,
  "PositionY" float,
  "Facing" varchar,
  "CurrentHealth" int
);

ALTER TABLE "MapMonster" ADD FOREIGN KEY ("MonsterId") REFERENCES "Monster" ("Id");

ALTER TABLE "MapMonster" ADD FOREIGN KEY ("MapId") REFERENCES "Map" ("Id");
