# Lab3_Backend
 # University Management System
 ## Features:
 ### This solution is implemented using DDD architecture.
 ### This solution requires 3 roles:
 - Admin
 - Teacher
 - Student
 - 
 ### Users are registered, authenticated, and authorized with firebase.
 ### This solution is connected to postgreSQL.

 ### End points are created using MediatR (commands,handlers) and entity frame work (DB first approach). Each endpoint is accessible only by the user authorized to.
 
 - Admin can create a course and set the Maximum number of students allowed and the enrollment date range.
 - A Teacher register that s/he can teach this course and create the time slot that s/he can teach at and can assign the course that they can teach to a time slot.
 - Student can enroll in a course if he is trying in date range allowed.
 ### GetRole endpoint is done by Omodel.
 ### A mail service is created to send an email to the student when the student enrolls in a class.
 ### Multi-tenancy is added by creating a table that matches each user with the schema branch name to perform then all its operation based on specified schema.
 ### Logging Microservices: 
 #### This logging microservice is added on role creation and each time rabbitMQ recieves a log it is added to mongoDB.
 
 - Enroll microservice
 - Mail microservice
 - RabbitMq Client package is installed.
 

 
