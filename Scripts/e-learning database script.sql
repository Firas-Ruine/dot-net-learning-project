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
    category_id INT,
    start_date DATE,
    end_date DATE,
    FOREIGN KEY (instructor_id) REFERENCES users(user_id) ON DELETE CASCADE ON UPDATE CASCADE,
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
    ('admin', 'adminpassword', 'admin@example.com', 'Admin', 'User', 3),
    ('student3', 'password4', 'student3@example.com', 'Jenny', 'Miller', 1),
    ('student4', 'password5', 'student4@example.com', 'David', 'Wilson', 1), 
    ('instructor2', 'password6', 'instructor2@example.com', 'James', 'Clark', 2),
    ('student5', 'password7', 'student5@example.com', 'Emma', 'Brown', 1),
    ('student6', 'password8', 'student6@example.com', 'Andrew', 'Lee', 1),
    ('student7', 'password9', 'student7@example.com', 'Olivia', 'Roberts', 1),
    ('instructor3', 'password10', 'instructor3@example.com', 'Sarah', 'Jones', 2),
    ('student8', 'password11','student8@example.com', 'Jack', 'Garcia', 1),
    ('student9', 'password12','student9@example.com', 'Lucas', 'Martinez', 1),
    ('student10', 'password13','student10@example.com', 'Sophia', 'Robinson', 1),  
    ('instructor4', 'password14','instructor4@example.com', 'Mason', 'Miller', 2),
    ('student11', 'password15','student11@example.com', 'Ava', 'Rodriguez', 1),
    ('student12', 'password16','student12@example.com', 'Mia', 'Hernandez', 1),  
    ('student13', 'password17','student13@example.com', 'Noah', 'Lopez', 1),
    ('instructor5', 'password18','instructor5@example.com', 'Elijah', 'Gonzalez', 2),
    ('student14', 'password19','student14@example.com', 'Isabella', 'Ramirez', 1),
    ('student15', 'password20','student15@example.com', 'Liam', 'Wilson', 1),
    ('student16', 'password21','student16@example.com', 'Emma', 'Wright', 1),    
    ('instructor6', 'password22','instructor6@example.com', 'Oliver', 'Lee', 2),
    ('student17', 'password23','student17@example.com', 'Amelia', 'Martin', 1),
    ('student18', 'password24','student18@example.com', 'Ethan', 'Perez', 1),
    ('student19', 'password25','student19@example.com', 'Harper', 'Nguyen', 1),
    ('instructor7', 'password26','instructor7@example.com', 'Evelyn', 'Hernandez', 2),
    ('student20', 'password27','student20@example.com', 'Abigail', 'Lopez', 1);


-- Sample data for courses table
INSERT INTO courses (course_name, description, instructor_id, start_date, end_date)
VALUES 
    ('Introduction to Programming', 'Learn the basics of programming with this introductory course.', 3, '2024-02-01', '2024-05-01'),
    ('Database Management', 'Explore the fundamentals of database management systems.', 3, '2024-03-01', '2024-06-01'),
    ('Web Design', 'Learn to design and build responsive websites with HTML, CSS and JavaScript.', 5, '2024-01-15', '2024-04-15'),
    ('Computer Architecture', 'Understand the principles and components of modern computer systems from a hardware perspective.', 2, '2024-02-15', '2024-05-15'),
    ('Operating Systems', 'Explore operating system concepts such as processes, threads, virtual memory and I/O handling.', 4, '2024-03-15', '2024-06-15'),
    ('Software Engineering', 'Gain skills for large scale software development including agile processes and version control.', 7, '2024-02-01', '2024-05-01'), 
    ('Data Structures', 'Learn about common data structures and algorithms and their implementation in various programming languages.', 1, '2024-03-01', '2024-06-01'),
    ('Networking Fundamentals', 'Understand computer network architectures, protocols and technologies with an emphasis on the TCP/IP stack.', 6, '2024-01-15', '2024-04-15'),
    ('Android App Development', 'Create engaging Android applications using Java and the Android software development kit.', 2, '2024-02-15', '2024-05-15'), 
    ('iOS App Development', 'Build mobile apps for iOS using Swift and the Xcode integrated development environment.', 4, '2024-03-15', '2024-06-15'), 
    ('Computer Graphics', 'Learn the underlying mathematical and implementation principles of 2D and 3D computer graphics.', 5, '2024-02-01', '2024-05-01'),
    ('Machine Learning', 'Gain hands-on experience applying machine learning algorithms to solve real-world problems.', 1, '2024-03-01', '2024-06-01'),
    ('Cybersecurity', 'Understand security issues and techniques for protecting computer systems and networks from threats.', 6, '2024-01-15', '2024-04-15'),
    ('Algorithms', 'Study algorithmic concepts including asymptotic analysis, sorting, searching and graph algorithms.', 3, '2024-02-15', '2024-05-15'),
    ('Compiler Design', 'Learn the principles and techniques for designing programming language compilers and interpreters.', 7, '2024-03-15', '2024-06-15'),
    ('Artificial Intelligence', 'Explore areas like machine learning, natural language processing and computer vision.', 2, '2024-02-01', '2024-05-01');

-- Sample data for enrollments table
INSERT INTO enrollments (user_id, course_id, enrollment_date)
VALUES 
    (1, 1, '2024-02-05'),
    (2, 1, '2024-02-05'),
    (1, 2, '2024-02-08'),
    (3, 3, '2024-01-15'),
    (4, 3, '2024-01-18'),
    (5, 4, '2024-02-15'),
    (6, 5, '2024-03-15'),
    (7, 5, '2024-03-18'),
    (8, 6, '2024-02-01'),
    (9, 7, '2024-03-01'),
    (10, 8, '2024-01-15'),
    (11, 9, '2024-02-15'),
    (12, 10, '2024-03-15'),
    (13, 11, '2024-02-01'),
    (14, 12, '2024-03-01'),
    (15, 13, '2024-01-15'),
    (16, 14, '2024-02-15');


-- Sample data for assignments table
INSERT INTO assignments (course_id, title, description, due_date)
VALUES 
    (1, 'Assignment 1', 'Complete the exercises from chapters 1 to 3.', '2024-03-01'),
    (2, 'Database Project', 'Design a database schema for an online learning management system.', '2024-04-01'),
    (3, 'Lab 1 Report', 'Write a report detailing your findings from the first laboratory assignment.', '2024-02-15'),
    (4, 'Midterm Exam', 'Complete the midterm exam covering core web design concepts.', '2024-03-15'),
    (5, 'Prototype 1', 'Develop a working prototype for your proposed operating system module.', '2024-05-15'), 
    (6, 'Project Proposal', 'Submit a proposal outlining your approach for the final software engineering project.', '2024-03-01'),
    (7, 'Data Structures Quiz', 'Complete an online quiz on different data structure implementations.', '2024-04-01'),
    (8, 'Routers Lab', 'Configure the Cisco routers provided in the networking lab.', '2024-03-15'),
    (9, 'User Interface Design', 'Produce wireframes and visual designs for your proposed Android app interfaces.', '2024-03-15'),
    (10, 'Midterm Presentation', 'Present your midterm iOS app progress to the class.', '2024-04-15'),
    (11, 'OpenGL Programming', 'Complete the tutorials and mini-projects from the course OpenGL programming book.', '2024-04-15'),
    (12, 'Final Paper', 'Submit a research paper on an approved machine learning topic.', '2024-06-01'), 
    (13, 'Network Monitoring Project', 'Install and configure Nagios to monitor key systems on your home network.', '2024-04-15'),
    (14, 'Algorithm Analysis', 'Complete analyses for several algorithms covered in class showing asymptotic running times.', '2024-04-30'),
    (15, 'TCP Implementation', 'Submit your implementation of the TCP protocol in Python.', '2024-05-15');


-- Sample data for submissions table
INSERT INTO submissions (assignment_id, user_id, submission_date, file_path)
VALUES 
    (1, 1, '2024-03-01', '/path/to/submission_file1.pdf'),
    (1, 2, '2024-03-01', '/path/to/submission_file2.pdf'),
    (3, 3, '2024-02-15', '/path/to/lab1_report_user3.docx'),
    (3, 4, '2024-02-15', '/path/to/lab1_report_user4.docx'),
    (5, 6, '2024-05-15', '/path/to/os_module_prototype1_user6.zip'),
    (6, 7, '2024-03-01', '/path/to/project_proposal_user7.pdf'),
    (7, 8, '2024-04-01', '/path/to/data_structures_quiz_user8.pdf'),
    (8, 9, '2024-03-15', '/path/to/routers_lab_user9.docx'), 
    (9, 10, '2024-03-15', '/path/to/android_ui_user10.pdf'),
    (10, 11, '2024-04-15', '/path/to/ios_midterm_user11.key'),
    (12, 13, '2024-06-01', '/path/to/ml_research_paper_user13.docx'),
    (13, 14, '2024-04-15', '/path/to/nagios_configuration_files_user14.zip'),
    (14, 15, '2024-04-30', '/path/to/algorithm_analysis_user15.pdf');


-- Sample data for grade table
INSERT INTO grades (submission_id, instructor_id, grade, feedback, grading_date)
VALUES 
    (1, 3, 90, 'Good work overall, but make sure to double-check your syntax.', '2024-03-02'),
    (2, 3, 85, 'Solid effort, but some concepts could use further clarification.', '2024-03-02'),
    (3, 1, 92, 'Excellent job on the lab report. Very thorough analysis.', '2024-02-16'),
    (4, 1, 88, 'Well written overall, but missing some key experimental details.', '2024-02-16'),
    (5, 2, 82, 'Good progress on the prototype but more work is needed before the deadline.', '2024-05-16'),
    (6, 4, 95, 'Outstanding proposal. Clear vision for the final project.', '2024-03-02'),
    (7, 5, 78, 'Quiz responses showed some gaps in understanding - please review material again.', '2024-04-02'),    
    (8, 6, 85, 'Lab configuration is mostly correct but could be better documented.', '2024-03-16'),
    (9, 7, 90, 'Very clean and intuitive UI designs. Great visual direction.', '2024-03-16'),
    (10, 8, 92, 'Presentation went very well. Demonstrated advanced iOS development skills.', '2024-04-16');

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
