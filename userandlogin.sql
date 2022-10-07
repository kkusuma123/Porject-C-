-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 07, 2022 at 08:51 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `userandlogin`
--

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `user` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `address` varchar(200) COLLATE utf8_unicode_ci NOT NULL,
  `tel` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`id`, `user`, `password`, `name`, `address`, `tel`) VALUES
(5, 'Kong', '1234', 'ทักษิณ สิงห์สุธรรม', '95 ม.19 ต.หนองโก อ.กระนวน จ.ขอนแก่น 40170', 956582462),
(9, 'siwadon', '0944200422', 'siwadon', 'dom7', 944200422),
(10, 'siw', '0944200422', 'siw', 'siw', 944200422),
(11, 'bamm', '31347', 'kusumi Misuku', '123sdfg', 610359860),
(17, 'kongkumi', '1234', 'kong nakup', '123', 956582462),
(18, 'bamm', '1234', 'กุสุมิ', '1234', 610359860),
(20, 'kusuyaaa', '31347', 'กุสุยาห์ ก่อประศาสน์วิทย์', 'Golden view resort', 610359860),
(22, 'joji_000', '12348765a', 'ชาคริต ทิพวัฒน์', '555/63 ต.เมืองเก่า อ.เมือง จ.ขอนแก่น', 930592001),
(23, 'Maple', '123456789m', 'Nutchanon Sincharoenlert', '435/8 ต.หมากแข้ง อ.เมือง จ.อุดรธานี 41000', 851632706);

-- --------------------------------------------------------

--
-- Table structure for table `productorder`
--

CREATE TABLE `productorder` (
  `product` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `productcount` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `price` int(11) NOT NULL,
  `user` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `address` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `status` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `qrimage` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `productorder`
--

INSERT INTO `productorder` (`product`, `productcount`, `price`, `user`, `address`, `status`, `qrimage`, `id`) VALUES
('ต่างหู สีชมพูซากุระ[1]\n ต่างหู สีม่วงลาเวนเดอร์[1]\n ', '2', 158, 'kong', 'หอ', 'จัดส่งสินค้าแล้ว', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_Qr\\1.jpg', 1),
('ต่างหู สีชมพูซากุระ[1]\n ', '1', 79, 'kong', 'หอ', 'จัดส่งสินค้าแล้ว', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_Qr\\2.jpg', 2),
('ต่างหู สีชมพูซากุระ[1]\n ต่างหู สีม่วงลาเวนเดอร์[1]\n ', '2', 158, 'ก้อง', 'หอ', 'จัดส่งสินค้าแล้ว', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_Qr\\1.jpg', 3),
('ต่างหู สีชมพูซากุระ[1]\n ', '1', 79, 'แบม', 'หอ', 'จัดส่งสินค้าแล้ว', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_Qr\\2.jpg', 4),
('ต่างหู สีชมพูซากุระ[1]\n ต่างหู สีม่วงลาเวนเดอร์[1]\n ', '2', 158, 'ช็อกชิฟ', 'หอ', 'จัดส่งสินค้าแล้ว', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_Qr\\1.jpg', 5),
('ต่างหู สีชมพูซากุระ[1]\n ', '1', 79, 'ดั้ม', 'หอ', 'จัดส่งสินค้าแล้ว', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_Qr\\2.jpg', 6),
('ต่างหู สีชมพูซากุระ[1]\n ', '1', 79, 'แบม', 'หอ', 'จัดส่งสินค้าแล้ว', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_Qr\\2.jpg', 7),
('ต่างหู สีชมพูซากุระ[1]\n ต่างหู สีม่วงลาเวนเดอร์[1]\n ', '2', 158, 'ก้ามปู', 'หอ', 'กำลังจัดส่งสินค้า', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_Qr\\1.jpg', 8),
('ต่างหู สีชมพูซากุระ[1]\n ต่างหู สีม่วงลาเวนเดอร์[1]\n ', '2', 158, 'แบม', 'หอ', 'กำลังจัดส่งสินค้า', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_Qr\\1.jpg', 70),
('ต่างหู สีชมพูซากุระ[1]\n ต่างหู สีม่วงลาเวนเดอร์[1]\n ', '2', 158, 'bam', 'หอ', 'กำลังจัดส่งสินค้า', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_Qr\\1.jpg', 71),
('ต่างหู สีม่วงลาเวนเดอร์[1]\n สร้อยข้อมือ สีม่วงฟ้า[2]\n แหวนสีเงิน[60][6]\n  ที่คาดผมผีเสื้อสีม่วง \n', '10', 820, 'วชิราพร', '435/8 ต.หมากแข้ง อ.เมือง จ.อุดรธานี 41000', 'กำลังจัดเตรียมสินค้า', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_Qr\\1.jpg', 72);

-- --------------------------------------------------------

--
-- Table structure for table `shoppingclass`
--

CREATE TABLE `shoppingclass` (
  `id` int(11) NOT NULL,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `amount` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `price` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `stock`
--

CREATE TABLE `stock` (
  `orders` varchar(250) COLLATE utf8_unicode_ci NOT NULL,
  `amount` varchar(250) COLLATE utf8_unicode_ci NOT NULL,
  `price` varchar(250) COLLATE utf8_unicode_ci NOT NULL,
  `image` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `stock`
--

INSERT INTO `stock` (`orders`, `amount`, `price`, `image`, `id`) VALUES
(' ที่คาดผมผีเสื้อสีทอง ', ' 10 ', ' 69', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_product\\1.jpg', 21),
(' ที่คาดผมผีเสื้อสีม่วง ', ' 10 ', ' 69', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_product\\2.jpg', 22),
('  ที่คาดผมดอกไม้สีชมพู ', '  10  ', '69', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_product\\3.jpg', 23),
(' ที่คาดผมดอกไม้สีขาว ', '  10  ', ' 69', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_product\\4.jpg', 24),
(' ที่หนีบผมผีเสื้อสีฟ้าน้ำทะเลอันดามัน', ' 10 ', '49', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_product\\6.jpg', 27),
('  ที่หนีบผมผีเสื้อขาว ', '  10  ', '49', 'C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_product\\5.jpg', 29);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `productorder`
--
ALTER TABLE `productorder`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `shoppingclass`
--
ALTER TABLE `shoppingclass`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stock`
--
ALTER TABLE `stock`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `productorder`
--
ALTER TABLE `productorder`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=80;

--
-- AUTO_INCREMENT for table `shoppingclass`
--
ALTER TABLE `shoppingclass`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=240;

--
-- AUTO_INCREMENT for table `stock`
--
ALTER TABLE `stock`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
