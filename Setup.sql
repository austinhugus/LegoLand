USE legoland;

-- CREATE TABLE kits(
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   price DECIMAL(6,2) NOT NULL,
--   PRIMARY KEY (id)
-- );
-- CREATE TABLE bricks(
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   color  VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
-- );
CREATE TABLE kitbricks(
  id int NOT NULL AUTO_INCREMENT,
  kitId int NOT NULL,
  brickId int NOT NULL,
  PRIMARY KEY(id),
  FOREIGN KEY (kitId)
    REFERENCES kits (id)
    ON DELETE CASCADE,
  FOREIGN KEY (brickId)
    REFERENCES bricks (id)
    ON DELETE CASCADE
)