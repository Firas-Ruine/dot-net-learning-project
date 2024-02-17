-- drop tables
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS roles;
DROP TABLE IF EXISTS courses;
DROP TABLE IF EXISTS enrollments;
DROP TABLE IF EXISTS assignments;
DROP TABLE IF EXISTS submissions;
DROP TABLE IF EXISTS grades;
DROP TABLE IF EXISTS quizzes;
DROP TABLE IF EXISTS questions;
DROP TABLE IF EXISTS quiz_submissions;
DROP TABLE IF EXISTS discussion_topics;
DROP TABLE IF EXISTS discussion_posts;

-- Create roles table
CREATE TABLE roles (
    role_id INT IDENTITY(1,1) PRIMARY KEY,
    role_name VARCHAR(20) NOT NULL
);

-- Create users table
CREATE TABLE users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL,
    firstname VARCHAR(50),
    lastname VARCHAR(50),
    role_id INT NOT NULL,
    FOREIGN KEY (role_id) REFERENCES roles(role_id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Create courses table
CREATE TABLE courses (
    course_id INT IDENTITY(1,1) PRIMARY KEY,
    course_name VARCHAR(100) NOT NULL,
    description TEXT,
    instructor_id INT,
    start_date DATE,
    end_date DATE,
    FOREIGN KEY (instructor_id) REFERENCES users(user_id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Create enrollments table
CREATE TABLE enrollments (
    enrollment_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    course_id INT,
    enrollment_date DATE,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE NO ACTION ON UPDATE NO ACTION, 
    FOREIGN KEY (course_id) REFERENCES courses(course_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- Create assignments table
CREATE TABLE assignments (
    assignment_id INT IDENTITY(1,1) PRIMARY KEY,
    course_id INT,
    title VARCHAR(100) NOT NULL,
    description TEXT,
    due_date DATE,
    FOREIGN KEY (course_id) REFERENCES courses(course_id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Create submissions table
CREATE TABLE submissions (
    submission_id INT IDENTITY(1,1) PRIMARY KEY,
    assignment_id INT,
    user_id INT,
    submission_date DATE,
    file_path VARCHAR(255),
    FOREIGN KEY (assignment_id) REFERENCES assignments(assignment_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- Create grades table
CREATE TABLE grades (
    grade_id INT IDENTITY(1,1) PRIMARY KEY,
    submission_id INT,
    instructor_id INT,
    grade DECIMAL(5, 2),
    feedback TEXT,
    grading_date DATE,
    FOREIGN KEY (submission_id) REFERENCES submissions(submission_id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (instructor_id) REFERENCES users(user_id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Create quizzes table
CREATE TABLE quizzes (
    quiz_id INT IDENTITY(1,1) PRIMARY KEY,
    course_id INT,
    title VARCHAR(100) NOT NULL,
    description TEXT,
    start_date DATE,
    end_date DATE,
    FOREIGN KEY (course_id) REFERENCES courses(course_id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Create questions table
CREATE TABLE questions (
    question_id INT IDENTITY(1,1) PRIMARY KEY,
    quiz_id INT,
    type VARCHAR(20),
    question_text TEXT,
    correct_answer TEXT,
    FOREIGN KEY (quiz_id) REFERENCES quizzes(quiz_id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Create quiz_submissions table
CREATE TABLE quiz_submissions (
    submission_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    quiz_id INT,
    submission_date DATE,
    score DECIMAL(5, 2),
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (quiz_id) REFERENCES quizzes(quiz_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- Create DiscussionTopic table
CREATE TABLE discussion_topics (
    topic_id INT IDENTITY(1,1) PRIMARY KEY,
    course_id INT,
    title VARCHAR(100) NOT NULL,
    description TEXT,
    start_date DATE,
    end_date DATE,
    FOREIGN KEY (course_id) REFERENCES courses(course_id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Create discussion_posts table
CREATE TABLE discussion_posts (
    PostID INT IDENTITY(1,1) PRIMARY KEY,
    topic_id INT,
    user_id INT,
    post_text TEXT,
    post_date DATE,
    FOREIGN KEY (topic_id) REFERENCES discussion_topics(topic_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);


-- Insert sample data into roles table
INSERT INTO roles (role_name)
VALUES 
    ('student'),
    ('instructor'),
    ('admin');


-- Sample data for users table
INSERT INTO users (username, password, email, firstname, lastname, role_id)
VALUES 
    ('student1', 'password1', 'student1@example.com', 'John', 'Doe', 1),
    ('student2', 'password2', 'student2@example.com', 'Jane', 'Smith', 1),
    ('instructor1', 'password3', 'instructor1@example.com', 'Michael', 'Johnson', 2),
    ('admin', 'adminpassword', 'admin@example.com', 'Admin', 'User', 3);

-- Sample data for courses table
INSERT INTO courses (course_name, description, instructor_id, start_date, end_date)
VALUES 
    ('Introduction to Programming', 'Learn the basics of programming with this introductory course.', 3, '2024-02-01', '2024-05-01'),
    ('Database Management', 'Explore the fundamentals of database management systems.', 3, '2024-03-01', '2024-06-01');

-- Sample data for enrollments table
INSERT INTO enrollments (user_id, course_id, enrollment_date)
VALUES 
    (1, 1, '2024-02-05'),
    (2, 1, '2024-02-05'),
    (1, 2, '2024-02-08');

-- Sample data for assignments table
INSERT INTO assignments (course_id, title, description, due_date)
VALUES 
    (1, 'Assignment 1', 'Complete the exercises from chapters 1 to 3.', '2024-03-01'),
    (2, 'Database Project', 'Design a database schema for an online learning management system.', '2024-04-01');

-- Sample data for submissions table
INSERT INTO submissions (assignment_id, user_id, submission_date, file_path)
VALUES 
    (1, 1, '2024-03-01', '/path/to/submission_file1.pdf'),
    (1, 2, '2024-03-01', '/path/to/submission_file2.pdf');

-- Sample data for grade table
INSERT INTO grades (submission_id, instructor_id, grade, feedback, grading_date)
VALUES 
    (1, 3, 90, 'Good work overall, but make sure to double-check your syntax.', '2024-03-02'),
    (2, 3, 85, 'Solid effort, but some concepts could use further clarification.', '2024-03-02');

-- Sample data for quizzes table
INSERT INTO quizzes (course_id, title, description, start_date, end_date)
VALUES 
    (1, 'Quiz 1', 'Test your understanding of basic programming concepts.', '2024-03-15', '2024-03-20'),
    (2, 'Quiz 2', 'Evaluate your knowledge of SQL and database management principles.', '2024-03-20', '2024-03-25');

-- Sample data for questions table
INSERT INTO questions (quiz_id, type, question_text, correct_answer)
VALUES 
    (1, 'multiple choice', 'What is the output of the following code snippet? \n int x = 5; \n x += 3; \n printf("%d", x);', '8'),
    (1, 'multiple choice', 'Which of the following data types is used to store whole numbers in C?', 'int'),
    (2, 'multiple choice', 'Which SQL keyword is used to retrieve data from a database table?', 'SELECT'),
    (2, 'multiple choice', 'What does SQL stand for?', 'Structured Query Language');

-- Sample data for quiz_submissions table
INSERT INTO quiz_submissions (user_id, quiz_id, submission_date, score)
VALUES 
    (1, 1, '2024-03-18', 80),
    (2, 1, '2024-03-18', 75);

-- Sample data for discussion_topics table
INSERT INTO discussion_topics (course_id, title, description, start_date, end_date)
VALUES 
    (1, 'Introduction and Course Overview', 'Discuss the objectives and structure of the course.', '2024-02-15', '2024-02-28'),
    (2, 'Database Design Best Practices', 'Share tips and insights on designing efficient database schemas.', '2024-03-01', '2024-03-15');

-- Sample data for discussion_posts table
INSERT INTO discussion_posts (topic_id, user_id, post_text, post_date)
VALUES 
    (1, 1, 'I''m excited to start learning programming! Any tips for beginners?', '2024-02-20'),
    (1, 3, 'Welcome to the course! Make sure to complete the readings and practice regularly.', '2024-02-21'),
    (2, 3, 'Normalization is key for database design. Avoid redundancy to ensure data integrity.', '2024-03-05');
