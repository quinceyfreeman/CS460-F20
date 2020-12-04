INSERT INTO Class(Name) VALUES 
('MTH111'), 
('CS242'), 
('ATH123');

INSERT INTO Tags(Name) VALUES
('Coding'),
('Study'),
('Reading');

INSERT INTO Assignment(ClassID, Priority, DueDate, Title, Notes) VALUES
(1, 2, '2020-11-30 12:00:00', 'Complete Ch.3', NULL),
(1, 1, '2020-11-28 10:30:00', 'Quiz', 'Covers CH.1-3'),
(1, 3, '2020-12-10 23:59:00', 'Turn in Assignment 8', NULL),
(2, 2, '2020-12-05 10:45:00', 'Complete Lab', 'Covers lecture material'),
(2, 1, '2020-11-30 09:59:00', 'Turn in report', 'Get sources from provided sites'),
(3, 3, '2020-12-12 12:59:00', 'Presentation', NULL);

INSERT INTO AssignmentTags(AssignmentID, TagID) VALUES
(1, 2),
(1, 3),
(2, 2),
(2, 3),
(3, 2),
(4, 1),
(4, 2),
(6, 2),
(6, 3);