-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le :  mar. 06 nov. 2018 à 19:58
-- Version du serveur :  10.1.35-MariaDB
-- Version de PHP :  7.2.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `ecoleenligne`
--

DELIMITER $$
--
-- Procédures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `add_cours` (IN `titre` VARCHAR(45), IN `description` LONGTEXT, IN `duree` INT)  BEGIN
INSERT into cours (titre, description, duree, status) 
values (titre, description, duree, 1);
COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `add_etudiant` (IN `prenom` VARCHAR(45), IN `nom` VARCHAR(45), IN `telephone` CHAR(10), IN `email` VARCHAR(45), IN `usager` VARCHAR(10), IN `motdepasse` VARCHAR(8))  BEGIN
INSERT into personne (prenom, nom, telephone, email, usager, motdepasse, status) 
values (prenom, nom, telephone, email, usager, motdepasse, 1);
COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `add_inscription` (IN `idcours` INT, IN `idpersonne` INT)  BEGIN
INSERT into inscription (idcours, idpersonne) values (idcours, idpersonne);
COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `connect` (IN `usager` VARCHAR(10), IN `pass` VARCHAR(8))  BEGIN
SELECT * FROM personne WHERE usager = usager && motdepasse = pass;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `cours_inscrit` (IN `idpersonne` INT)  BEGIN
SELECT cours.titre FROM cours
INNER JOIN inscription ON cours.idcours = inscription.idcours 
WHERE inscription.idpersonne = idpersonne;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `cours_non_inscrit` (IN `idpersonne` INT)  BEGIN
SELECT * from cours WHERE cours.status = 1 and cours.idcours not in (SELECT cours.idcours
FROM cours INNER JOIN inscription ON cours.idcours = inscription.idcours 
WHERE inscription.idpersonne = idpersonne);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `select_cours` ()  BEGIN
SELECT * FROM cours;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `select_cours_actifs` ()  BEGIN
SELECT * FROM cours WHERE cours.status = 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `select_cours_inactifs` ()  BEGIN
SELECT * FROM cours WHERE cours.status = 0;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `supprimer_cours` (IN `idcours` INT)  BEGIN
UPDATE cours SET status = 0 WHERE cours.idcours = idcours;
COMMIT;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `cours`
--

CREATE TABLE `cours` (
  `idcours` int(11) NOT NULL,
  `titre` varchar(45) NOT NULL,
  `description` longtext NOT NULL,
  `duree` int(11) NOT NULL,
  `status` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `cours`
--

INSERT INTO `cours` (`idcours`, `titre`, `description`, `duree`, `status`) VALUES
(1, 'Administration', 'Comment bien gérer', 75, b'0'),
(2, 'Informatique', 'Tecnologie', 80, b'1'),
(3, 'Art et Designe', 'Vous débordez d\'idées et de créativité?', 50, b'1'),
(4, 'Soins de Santé', 'Spécialiser dans le secteur des soins de santé', 80, b'1'),
(5, 'Adm', 'Comment bien gérer', 70, b'1'),
(6, 'Gastronomie', 'Comment bien cuisiner', 20, b'0'),
(7, 'Web', 'web web web', 50, b'1'),
(8, 'Java', 'java java', 50, b'1'),
(9, 'Cuisine', 'Comment bien cuisiner', 30, b'1'),
(10, 'Études Juridiques', 'Études Juridiques', 30, b'1'),
(11, 'Soins Dentaires', 'Domaine de soins dentaires', 55, b'1'),
(12, 'HTML5', 'asasas', 45, b'1'),
(13, 'C#', 'Programmation', 15, b'1');

-- --------------------------------------------------------

--
-- Structure de la table `download`
--

CREATE TABLE `download` (
  `iddownload` int(11) NOT NULL,
  `idcours` int(11) NOT NULL,
  `document` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `inscription`
--

CREATE TABLE `inscription` (
  `idinscription` int(11) NOT NULL,
  `idcours` int(11) NOT NULL,
  `idpersonne` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `inscription`
--

INSERT INTO `inscription` (`idinscription`, `idcours`, `idpersonne`) VALUES
(35, 1, 1),
(36, 2, 1),
(38, 3, 1),
(39, 4, 1),
(40, 5, 1),
(41, 7, 1),
(42, 3, 4),
(43, 12, 1),
(44, 6, 1),
(45, 8, 1),
(46, 9, 14),
(47, 12, 14),
(48, 9, 1),
(49, 1, 6);

-- --------------------------------------------------------

--
-- Structure de la table `personne`
--

CREATE TABLE `personne` (
  `idpersonne` int(11) NOT NULL,
  `prenom` varchar(45) NOT NULL,
  `nom` varchar(45) NOT NULL,
  `telephone` char(10) NOT NULL,
  `email` varchar(45) NOT NULL,
  `usager` varchar(10) NOT NULL,
  `motdepasse` varchar(8) NOT NULL,
  `status` bit(1) NOT NULL,
  `tuteur` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `personne`
--

INSERT INTO `personne` (`idpersonne`, `prenom`, `nom`, `telephone`, `email`, `usager`, `motdepasse`, `status`, `tuteur`) VALUES
(1, 'Rose', 'Nogueira', '11111111', 'nogueira_rose@outlook.com', 'rose', 'rose', b'1', b'0'),
(2, 'Vini', 'Nogueira', '222222222', 'vini_mcdba@outlook.com', 'vini', 'vini', b'1', b'0'),
(3, 'Roseli', 'Leite', '333333333', 'nogueira_rose@yahoo.com', 'roseli', 'roseli', b'1', b'0'),
(4, 'Martin', 'Etudiant', '444444444', 'martin.roy@collegecdi.ca', 'martin', 'martin', b'1', b'0'),
(5, 'Adimin', 'Adm', '555555555', 'aaaaa@collegecdi.ca', 'magister', 'signum', b'1', b'1'),
(6, 'Rosa', 'Branca', 'ffff', 'ffff@jjj.com', 'rosa', 'rosa', b'1', b'0'),
(7, 'Rosi', 'Leite', '5656565656', 'aaaa@test.com', 'rosi', 'rosi', b'1', b'0'),
(8, 'Nicole', 'Leite', 'cxsfsdfsdf', 'aaaa@test.com', 'nick', 'nick', b'1', b'0'),
(9, 'Nogueira', 'Nog', 'ssss', 'aaaa@test.com', 'nogueira', 'nogueira', b'1', b'0'),
(11, 'Leite', 'Leite', 'dfdfdf', 'aaaa@test.com', 'leite', 'leite', b'1', b'0'),
(12, 'Leite', 'Leite', 'dfdfdf', 'aaaa@test.com', 'leite', 'leite', b'1', b'0'),
(13, 'Leite', 'Leite', 'dfdfdf', 'aaaa@test.com', 'leite', 'leite', b'1', b'0'),
(14, 'Vanderlei', 'Vanderlei', 'aaaaaa', 'aaaa@test.com', 'vanderlei', 'vanderle', b'1', b'0'),
(15, 'Mario', 'Santos', '2222222', 'aaaa@test.com', 'mario', 'mario', b'1', b'0'),
(16, 'Maria', 'Desjardins', '1111111', 'aaaa@test.com', 'maria', 'maria', b'1', b'0'),
(17, 'Maria', 'Desjardins', '1111111', 'aaaa@test.com', 'maria', 'maria', b'1', b'0');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `cours`
--
ALTER TABLE `cours`
  ADD PRIMARY KEY (`idcours`);

--
-- Index pour la table `download`
--
ALTER TABLE `download`
  ADD PRIMARY KEY (`iddownload`);

--
-- Index pour la table `inscription`
--
ALTER TABLE `inscription`
  ADD PRIMARY KEY (`idinscription`);

--
-- Index pour la table `personne`
--
ALTER TABLE `personne`
  ADD PRIMARY KEY (`idpersonne`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `cours`
--
ALTER TABLE `cours`
  MODIFY `idcours` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT pour la table `download`
--
ALTER TABLE `download`
  MODIFY `iddownload` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `inscription`
--
ALTER TABLE `inscription`
  MODIFY `idinscription` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=50;

--
-- AUTO_INCREMENT pour la table `personne`
--
ALTER TABLE `personne`
  MODIFY `idpersonne` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
