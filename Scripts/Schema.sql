CREATE TABLE Posts(
	PostID int NOT NULL AUTO_INCREMENT,
	Title varchar(255) NOT NULL,
	Content varchar(255),
	PRIMARY KEY (PostID)
)

CREATE TABLE Users(
	UserID int NOT NULL AUTO_INCREMENT,
	Name varchar(255),
	Email varchar(320),
	Password varchar(320),
	PRIMARY KEY (UserID)
)

CREATE TABLE Comments(
	CommentID int NOT NULL AUTO_INCREMENT,
	Description varchar(255),
	PRIMARY KEY (CommentID),
	PostID int,
	UserID int,
	FOREIGN KEY (PostID) REFERENCES Posts(PostID),
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
)