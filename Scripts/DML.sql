
/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

LOCK TABLES `Clients` WRITE;
/*!40000 ALTER TABLE `Clients` DISABLE KEYS */;
INSERT INTO `Clients` (`ClientId`, `FirstName`, `LastName`, `Email`, `Phone`, `CreatedAt`) VALUES (1,'Alexia','Paige','alexia@example.com','555-0101','2026-10-14 23:19:08'),(2,'Vignesh','mc','vignesh@example.com','555-0102','2026-10-14 23:19:08'),(3,'David','Wilson','david@example.com','555-0103','2026-10-14 23:19:08'),(4,'Maria','Garcia','maria@example.com','555-0104','2026-10-14 23:19:08'),(5,'James','Brown','james@example.com','555-0105','2026-10-14 23:19:08'),(6,'Nishant','Chinnasami','nishant@gmail.com','555-0106','2026-10-15 08:02:49');
/*!40000 ALTER TABLE `Clients` ENABLE KEYS */;
UNLOCK TABLES;

LOCK TABLES `Exercises` WRITE;
/*!40000 ALTER TABLE `Exercises` DISABLE KEYS */;
INSERT INTO `Exercises` (`ExerciseId`, `ExerciseName`, `MuscleGroup`, `Equipment`, `Difficulty`) VALUES (1,'Barbell Squat','Legs','Barbell','Intermediate'),(3,'Deadlift','Back','Barbell','Advanced'),(4,'Lat Pulldown','Back','Cable Machine','Beginner'),(5,'Shoulder Press','Shoulders','Dumbbells','Intermediate'),(6,'Biceps Curl','Arms','Dumbbells','Beginner'),(7,'Triceps Pushdown','Arms','Cable Machine','Beginner'),(8,'Leg Press','Legs','Machine','Beginner'),(9,'Romanian Deadlift','Hamstrings','Barbell','Intermediate'),(10,'Incline Dumbbell Press','Chest','Dumbbells','Intermediate'),(11,'Cable Fly','Chest','Cable Machine','Beginner'),(12,'Pull Up','Back','Pull Up Bar','Advanced'),(13,'Lateral Raise','Shoulders','Dumbbells','Beginner'),(14,'Walking Lunge','Legs','Dumbbells','Intermediate');
/*!40000 ALTER TABLE `Exercises` ENABLE KEYS */;
UNLOCK TABLES;

LOCK TABLES `Settings` WRITE;
/*!40000 ALTER TABLE `Settings` DISABLE KEYS */;
INSERT INTO `Settings` (`SettingId`, `SettingKey`, `SettingValue`) VALUES (1,'theme','light');
/*!40000 ALTER TABLE `Settings` ENABLE KEYS */;
UNLOCK TABLES;

LOCK TABLES `Trainers` WRITE;
/*!40000 ALTER TABLE `Trainers` DISABLE KEYS */;
INSERT INTO `Trainers` (`TrainerId`, `FirstName`, `LastName`, `Email`, `Specialty`) VALUES (1,'Alex','Johnson','alex.trainer@example.com','Strength Training'),(2,'Maria','Garcia','maria.trainer@example.com','Hypertrophy'),(3,'James','Lee','james.trainer@example.com','Weight Loss'),(4,'Nina','Thomas','nina.trainer@example.com','Conditioning'),(5,'David','Clark','david.trainer@example.com','Bodybuilding'),(7,'Vignesh','MC','vignesh@gmail.com','Coach');
/*!40000 ALTER TABLE `Trainers` ENABLE KEYS */;
UNLOCK TABLES;

LOCK TABLES `TrainingPlans` WRITE;
/*!40000 ALTER TABLE `TrainingPlans` DISABLE KEYS */;
INSERT INTO `TrainingPlans` (`TrainingPlanId`, `PlanName`, `ClientId`, `TrainerId`, `StartDate`, `DurationWeeks`) VALUES (1,'Beginner Strength',1,1,'2026-10-01',8),(2,'Hypertrophy Phase 1',2,2,'2026-10-05',12),(3,'Fat Loss Foundation',3,3,'2026-10-07',8),(4,'Conditioning Block',4,4,'2026-10-10',6),(5,'Bodybuilding Base',5,5,'2026-10-12',12);
/*!40000 ALTER TABLE `TrainingPlans` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

