-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Сен 08 2026 г., 21:57
-- Версия сервера: 8.4.7
-- Версия PHP: 8.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `shop_db`
--

-- --------------------------------------------------------

--
-- Структура таблицы `clients`
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `id_client` int NOT NULL AUTO_INCREMENT,
  `fio_client` varchar(255) NOT NULL,
  `phone_client` varchar(50) NOT NULL,
  `email_client` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_client`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `clients`
--

INSERT INTO `clients` (`id_client`, `fio_client`, `phone_client`, `email_client`) VALUES
(1, 'Волков Николай Дмитриевич', '+7 (912) 345-67-89', 'volkov.n@mail.ru'),
(2, 'Петров Святослав Дмитриевич', '+7 (923) 456-78-90', 'petrov.s@yandex.ru'),
(3, 'Сидоров Егор Павлович', '+7 (934) 567-89-01', 'sidorov.e@gmail.com'),
(4, 'Козлов Борис Алексеевич', '+7 (945) 678-90-12', 'kozlov.b@mail.ru'),
(5, 'Николаев Тарас Денисович', '+7 (956) 789-01-23', 'nikolaev.t@yandex.ru');

-- --------------------------------------------------------

--
-- Структура таблицы `employees`
--

DROP TABLE IF EXISTS `employees`;
CREATE TABLE IF NOT EXISTS `employees` (
  `id_employee` int NOT NULL AUTO_INCREMENT,
  `fio_employee` varchar(255) NOT NULL,
  `post_employee` varchar(100) NOT NULL,
  `phone_employee` varchar(50) NOT NULL,
  PRIMARY KEY (`id_employee`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `employees`
--

INSERT INTO `employees` (`id_employee`, `fio_employee`, `post_employee`, `phone_employee`) VALUES
(1, 'Смирнов Алексей Иванович', 'Менеджер по продажам', '+7 (901) 234-56-78'),
(2, 'Васильев Федор Петрович', 'Администратор', '+7 (912) 345-67-80'),
(3, 'Федоров Дмитрий Сергеевич', 'Консультант', '+7 (923) 456-78-91'),
(4, 'Морозова Анна Владимировна', 'Кассир', '+7 (934) 567-89-02'),
(5, 'Павлов Игорь Олегович', 'Управляющий', '+7 (945) 678-90-13');

-- --------------------------------------------------------

--
-- Структура таблицы `items`
--

DROP TABLE IF EXISTS `items`;
CREATE TABLE IF NOT EXISTS `items` (
  `id_items` int NOT NULL AUTO_INCREMENT,
  `title_item` varchar(255) NOT NULL,
  `sum_item` decimal(10,2) NOT NULL,
  `count_items` int NOT NULL DEFAULT '0',
  `id_SubCateg` int DEFAULT NULL,
  PRIMARY KEY (`id_items`),
  KEY `idx_items_subcateg` (`id_SubCateg`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `items`
--

INSERT INTO `items` (`id_items`, `title_item`, `sum_item`, `count_items`, `id_SubCateg`) VALUES
(1, 'Костюм деловой \"Директор\"', 18999.00, 15, 1),
(2, 'Костюм двойка классический черный', 15999.00, 12, 1),
(3, 'Костюм тройка с жилетом \"Премиум\"', 24999.00, 8, 2),
(4, 'Пиджак классический синий', 8999.00, 20, 3),
(5, 'Пиджак спортивный на пуговицах', 7499.00, 10, 4),
(6, 'Рубашка классическая белая', 4499.00, 35, 5),
(7, 'Рубашка классическая голубая', 4499.00, 25, 6),
(8, 'Рубашка классическая клетка', 4999.00, 18, 6),
(9, 'Сорочка повседневная серая', 3499.00, 30, 7),
(10, 'Джинсы классические синие', 5999.00, 22, 8),
(11, 'Джинсы классические чёрные', 5999.00, 18, 8),
(12, 'Джинсы скинни светлые', 5499.00, 12, 9),
(13, 'Брюки деловые чёрные', 7499.00, 14, 10),
(14, 'Чиносы бежевые', 4999.00, 20, 11),
(15, 'Чиносы оливковые', 4999.00, 16, 11),
(16, 'Куртка зимняя утеплённая', 14999.00, 8, 12),
(17, 'Куртка зимняя кожаная', 22999.00, 5, 12),
(18, 'Пальто осеннее классическое', 12999.00, 10, 13),
(19, 'Плащ-тренч водоотталкивающий', 9999.00, 6, 14),
(20, 'Футболка хлопковая белая', 1999.00, 45, 15),
(21, 'Футболка хлопковая чёрная', 1999.00, 40, 15),
(22, 'Поло классическое белое', 3499.00, 20, 16),
(23, 'Поло классическое синее', 3499.00, 18, 16),
(24, 'Галстук шёлковый синий', 2999.00, 30, 17),
(25, 'Галстук шёлковый красный', 2999.00, 25, 17),
(26, 'Ремень классический чёрный', 3999.00, 20, 18),
(27, 'Ремень классический коричневый', 3999.00, 18, 18),
(28, 'Запонки серебряные', 2999.00, 15, 19),
(29, 'Запонки золотые', 4999.00, 8, 19);

-- --------------------------------------------------------

--
-- Структура таблицы `korzinaorders`
--

DROP TABLE IF EXISTS `korzinaorders`;
CREATE TABLE IF NOT EXISTS `korzinaorders` (
  `id_korzina` int NOT NULL AUTO_INCREMENT,
  `id_items` int NOT NULL,
  `count_items` int NOT NULL,
  `id_MainCateg` int DEFAULT NULL,
  `id_order` int DEFAULT NULL,
  PRIMARY KEY (`id_korzina`),
  KEY `id_MainCateg` (`id_MainCateg`),
  KEY `idx_korzina_items` (`id_items`),
  KEY `idx_korzina_order` (`id_order`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `korzinaorders`
--

INSERT INTO `korzinaorders` (`id_korzina`, `id_items`, `count_items`, `id_MainCateg`, `id_order`) VALUES
(1, 2, 1, 1, NULL),
(2, 2, 1, 1, NULL),
(3, 2, 1, 1, NULL),
(4, 2, 1, 1, NULL),
(5, 11, 1, 2, NULL),
(6, 11, 1, 2, NULL),
(7, 14, 1, 2, NULL),
(8, 13, 1, 2, NULL),
(9, 15, 1, 2, NULL),
(10, 17, 1, 2, NULL),
(11, 7, 1, 3, NULL),
(12, 6, 1, 3, NULL),
(13, 5, 1, 3, NULL),
(14, 17, 1, 3, NULL),
(15, 18, 1, 3, NULL),
(16, 14, 1, 4, NULL),
(17, 14, 1, 4, NULL),
(18, 14, 1, 4, NULL),
(19, 14, 1, 4, NULL),
(20, 14, 1, 4, NULL),
(21, 19, 1, 5, NULL),
(22, 19, 1, 5, NULL),
(23, 19, 1, 5, NULL),
(24, 19, 1, 5, NULL),
(25, 19, 1, 5, NULL),
(26, 13, 1, 5, NULL),
(27, 13, 1, 5, NULL),
(28, 13, 1, 5, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `maincateg`
--

DROP TABLE IF EXISTS `maincateg`;
CREATE TABLE IF NOT EXISTS `maincateg` (
  `id_MainCateg` int NOT NULL AUTO_INCREMENT,
  `title_MainCateg` varchar(255) NOT NULL,
  PRIMARY KEY (`id_MainCateg`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `maincateg`
--

INSERT INTO `maincateg` (`id_MainCateg`, `title_MainCateg`) VALUES
(1, 'Костюмы и пиджаки'),
(2, 'Рубашки и сорочки'),
(3, 'Джинсы и брюки'),
(4, 'Верхняя одежда'),
(5, 'Футболки и поло'),
(6, 'Аксессуары');

-- --------------------------------------------------------

--
-- Структура таблицы `orders`
--

DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `id_order` int NOT NULL AUTO_INCREMENT,
  `date_order` datetime NOT NULL,
  `id_client` int NOT NULL,
  `sum_order` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id_order`),
  KEY `idx_orders_client` (`id_client`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `orders`
--

INSERT INTO `orders` (`id_order`, `date_order`, `id_client`, `sum_order`) VALUES
(1, '2026-09-09 02:15:28', 1, 63996.00),
(2, '2026-09-09 02:49:40', 2, 52494.00),
(3, '2026-09-09 02:49:52', 5, 52495.00),
(4, '2026-09-09 02:50:28', 4, 24995.00),
(5, '2026-09-09 02:50:38', 2, 72492.00);

-- --------------------------------------------------------

--
-- Структура таблицы `subcateg`
--

DROP TABLE IF EXISTS `subcateg`;
CREATE TABLE IF NOT EXISTS `subcateg` (
  `id_SubCateg` int NOT NULL AUTO_INCREMENT,
  `title_SubCateg` varchar(255) NOT NULL,
  `id_MainCateg` int DEFAULT NULL,
  PRIMARY KEY (`id_SubCateg`),
  KEY `id_MainCateg` (`id_MainCateg`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `subcateg`
--

INSERT INTO `subcateg` (`id_SubCateg`, `title_SubCateg`, `id_MainCateg`) VALUES
(1, 'Костюмы деловые (двойка)', 1),
(2, 'Костюмы тройки (с жилетом)', 1),
(3, 'Пиджаки классические', 1),
(4, 'Пиджаки спортивные', 1),
(5, 'Рубашки классические белые', 2),
(6, 'Рубашки классические цветные', 2),
(7, 'Сорочки повседневные', 2),
(8, 'Джинсы классические', 3),
(9, 'Джинсы скинни', 3),
(10, 'Брюки деловые', 3),
(11, 'Чиносы (повседневные брюки)', 3),
(12, 'Куртки зимние', 4),
(13, 'Пальто осенние', 4),
(14, 'Плащи и тренчи', 4),
(15, 'Футболки хлопковые', 5),
(16, 'Поло классические', 5),
(17, 'Галстуки', 6),
(18, 'Ремни классические', 6),
(19, 'Запонки', 6);

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `items`
--
ALTER TABLE `items`
  ADD CONSTRAINT `items_ibfk_1` FOREIGN KEY (`id_SubCateg`) REFERENCES `subcateg` (`id_SubCateg`) ON DELETE SET NULL;

--
-- Ограничения внешнего ключа таблицы `korzinaorders`
--
ALTER TABLE `korzinaorders`
  ADD CONSTRAINT `korzinaorders_ibfk_1` FOREIGN KEY (`id_items`) REFERENCES `items` (`id_items`) ON DELETE CASCADE,
  ADD CONSTRAINT `korzinaorders_ibfk_2` FOREIGN KEY (`id_MainCateg`) REFERENCES `maincateg` (`id_MainCateg`) ON DELETE SET NULL,
  ADD CONSTRAINT `korzinaorders_ibfk_3` FOREIGN KEY (`id_order`) REFERENCES `orders` (`id_order`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`id_client`) REFERENCES `clients` (`id_client`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `subcateg`
--
ALTER TABLE `subcateg`
  ADD CONSTRAINT `subcateg_ibfk_1` FOREIGN KEY (`id_MainCateg`) REFERENCES `maincateg` (`id_MainCateg`) ON DELETE SET NULL;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
