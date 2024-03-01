DROP TABLE IF EXISTS units;
DROP TABLE IF EXISTS enemies;
DROP TABLE IF EXISTS player;
DROP TABLE IF EXISTS traits;
DROP TABLE IF EXISTS passives;
DROP TABLE IF EXISTS abilities;
DROP TABLE IF EXISTS tribes;
DROP TABLE IF EXISTS specials;
DROP TABLE IF EXISTS position;

CREATE TABLE player (
    id SERIAL PRIMARY KEY NOT NULL,
    health INTEGER NOT NULL,
    types TEXT NOT NULL
);

CREATE TABLE units (
    id SERIAL PRIMARY KEY NOT NULL, 
    name VARCHAR(30) NOT NULL, 
    health INTEGER NOT NULL,
    energy INTEGER NOT NULL,
    damage INTEGER NOT NULL,
    attack_range INTEGER NOT NULL,
    tribe_id INT NOT NULL,
    trait_id INT NOT NULL,
    special_id INT NOT NULL,
    position_id INT NOT NULL
);

CREATE TABLE enemies (
    id SERIAL PRIMARY KEY NOT NULL,
    name VARCHAR(30) NOT NULL,
    health INTEGER NOT NULL,
    damage INTEGER NOT NULL,
    attack_range INTEGER NOT NULL
);

CREATE TABLE passives (
    id SERIAL PRIMARY KEY NOT NULL,
    unit VARCHAR(20) NOT NULL,
    name VARCHAR(15) NOT NULL,
    description VARCHAR(100) NOT NULL
);
    
CREATE TABLE abilities (
    id SERIAL PRIMARY KEY NOT NULL,
    unit VARCHAR(20) NOT NULL,
    name VARCHAR(15) NOT NULL,
    description VARCHAR(100) NOT NULL
);

CREATE TABLE tribes (
    id SERIAL PRIMARY KEY NOT NULL,
    name VARCHAR(15) NOT NULL,
    description VARCHAR(100) NOT NULL,
    buff VARCHAR(30) NOT NULL
);

CREATE TABLE traits (
    id SERIAL PRIMARY KEY NOT NULL,
    name VARCHAR(15) NOT NULL,
    description VARCHAR(100) NOT NULL,
    buff VARCHAR(30) NOT NULL
);

CREATE TABLE specials (
    id SERIAL PRIMARY KEY NOT NULL,
    name VARCHAR(15) NOT NULL,
    description VARCHAR(100) NOT NULL,
    buff VARCHAR(30) NOT NULL
);

CREATE TABLE position (
    id SERIAL PRIMARY KEY NOT NULL,
    x_pos INTEGER NOT NULL,
    y_pos INTEGER NOT NULL
);

/*Populating tables*/

/*positions*/
DECLARE @SecondValue INT = 1;
DECLARE @ThirdValue INT = 1;

WHILE @SecondValue <= 27
BEGIN
    WHILE @ThirdValue <= 9
    BEGIN
        INSERT INTO position VALUES (@SecondValue, @ThirdValue, 1);
        SET @ThirdValue = @ThirdValue + 1;
    END
    
    SET @SecondValue = @SecondValue + 1;
    SET @ThirdValue = 1;
END
/*stages*/

