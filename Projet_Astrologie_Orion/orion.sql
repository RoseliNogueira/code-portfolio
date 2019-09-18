-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le :  lun. 22 oct. 2018 à 22:00
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
-- Base de données :  `orion`
--

DELIMITER $$
--
-- Procédures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `horoscopes` (IN `numero` INT)  BEGIN
SELECT * FROM horoscopes WHERE id = numero;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `horoscopes`
--

CREATE TABLE `horoscopes` (
  `id` int(11) NOT NULL,
  `signe` varchar(35) COLLATE utf8_unicode_ci NOT NULL,
  `datesigne` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `climatastral` longtext COLLATE utf8_unicode_ci NOT NULL,
  `humeur` longtext COLLATE utf8_unicode_ci NOT NULL,
  `amour` longtext COLLATE utf8_unicode_ci NOT NULL,
  `argent` longtext COLLATE utf8_unicode_ci NOT NULL,
  `travail` longtext COLLATE utf8_unicode_ci NOT NULL,
  `photo` varchar(45) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table `horoscopes`
--

INSERT INTO `horoscopes` (`id`, `signe`, `datesigne`, `climatastral`, `humeur`, `amour`, `argent`, `travail`, `photo`) VALUES
(1, 'Belier', 'du 21 mars au 19 avril', 'Sûr de vous et optimiste, vous êtes en harmonie avec votre entourage, les échanges sont très positifs. Un intense besoin de repos vous envahit. Il serait vain de résister, il est temps de recharger vos batteries !', 'Votre efficacité est en accroissement ce vendredi 28 septembre, ce qui vous permet de lancer de nouveaux projets intéressants.', 'Votre paix affective est votre priorité dans le cadre de vos amours. Vous aurez à coeur de vous rendre in dispensable aux yeux de votre partenaire, qui vous donnera la reconnaissance que vous espérez.', 'Vous aurez à coeur de parfaire vos comptes et d\'être ainsi tout à fait irréprochable. Analysez les failles', 'Vous allez-vous attaquer à des soucis en mettant au point des plans inédits et qui font fonctionner à merveille.', 'Images/Belier.jpg'),
(2, 'Taureau', 'du 20 avril au 20 mai', 'Vous voyez la vie en rose, aujourd\'hui. Votre libre expression est favorisée et gagne largement en douceur. Les excès alimentaires vous fragiliseraient aujourd\'hui. Ne surchargez pas davantage votre organisme !', 'Votre énergie est en hausse ce vendredi 28 septembre, ne vous en prenez pas à tout le monde... Agissez là où il le faut sans vous disperser.', 'Des satisfactions amoureuses sont à portée à condition que vous mettiez de côté les schémas du passé qui aujourd\'hui vous mettent des bâtons dans les roues.', 'Vous manquez de concentration, aujourd\'hui. La neutralité sera la meilleure politique à suivre, n\'entamez rien d\'important.', 'C\'est hors du cadre de votre travail quotidien que vous puiserez le maximum d\'énergie pour progresser au plan professionnel.', 'Images/Taureau.jpg'),
(3, 'Gémeaux', 'du 21 mai au 20 juin', 'Votre humeur incertaine, mi-figue mi-raisin, détonante et passive, vous met des bâtons dans les roues. La sédentarité du quotidien se fait sentir. C\'est le moment de vous consacrer à votre sport favori, et de boire davantage.', 'Votre entourage familial ne vous semble pas suffisamment solidaire ce vendredi 28 septembre... Êtes-vous sûr de ne pas trop lui en demander ?', 'Vos relations avec votre partenaire sont très nettement favorisées sous l\'angle de la complicité. Mais les étincelles sensuelles s\'annoncent en recul.', 'Vous ressentez un intense besoin de trouver davantage d\'équilibre dans vos comptes. Modérez vos critiques pour rebâtir sur les meilleures bases de négociations.', 'Les critiques peuvent être constructives si vous les entendez avec philosophie, c\'est cette optique-là qu\'il faut approfondir.', 'Images/Gemeaux.jpg'),
(4, 'Cancer', 'du 21 juin au 22 juillet', 'Vous vous sentirez moins en harmonie avec votre entourage. De bonnes nouvelles sont en vue pourtant ! Un besoin de calme se fait sentir malgré tout, écoutez-le et mettez le frein à vos activités secondaires.', 'Une solution salutaire à un souci important s\'offrira spontanément à vous. Vous aurez une chance insolente ce vendredi 28 septembre.', 'Vous arrivez enfin à la fin d\'un souci relationnel, aujourd\'hui. Affronter la réalité vous porte chance.', 'Votre vie amicale pourra vous faire gagner en clarté de vues par rapport à la gestion de votre budget, aujourd\'hui.', 'Vous aurez tendance à trop en faire aujourd\'hui et à paraître louche aux yeux de vos supérieurs, montrez patte blanche.', 'Images/Cancer.jpg'),
(5, 'Lion', 'du 23 juillet au 22 août', 'Vous serez plus disposé à vous pencher sur les préoccupations de votre entourage et à leur apporter votre soutien. Faites le plein de vitamines, vous allez traverser un mois très actif, qui va mobiliser toutes vos énergies.', 'Vous devrez faire des concessions pour arriver à une entente satisfaisante, vous ne le regretterez pas ce vendredi 28 septembre.', 'L\'ivresse des sens sera la tentation majeure de cette journée. Vivez l\'instant présent sans vous préoccuper de l\'avenir, chaque chose en son temps... Pour l\'heure, savourez ce qui vous tend les bras.', 'Vous serez largement inspiré pour communiquer la chaleur de vos idéaux mais pas tellement avec des arguments concrets !', 'Vous êtes submergé de coups de téléphone, de visites... Il sera difficile de plonger dans un travail de fond !', 'Images/Lion.jpg'),
(6, 'Vierge', '23 août au 22 sept', 'Le printemps arrive dans votre coeur. Laissez vous porter par ce que vous ressentez. Vous aurez plus facilement l\'occasion de vous occuper de vous, un brin d\'égoïsme en ce sens vous sera favorable, vous avez encore besoin de repos.', 'Vous allez devoir ménager des susceptibilités contraires... Restez absolument neutre et surtout gardez votre calme ce vendredi 28 septembre.', 'Vous saurez éviter un piège dans vos relations. Soyez vous-même coûte que coûte, tout simplement et sans fards.', 'Les projets de ce jour vont remettre en question certains aspects de votre vie. Ne vous emballez pas pour autant !', 'Vous canalisez votre énergie à améliorer votre carrière dans la bonne direction. Vous serez ravi de constater que des doutes s\'envolent.', 'Images/Vierge.jpg'),
(7, 'Balance', '23 sept au 22 oct', 'Vous récolterez les fruits de vos efforts. Vous serez ravi d\'apprendre l\'opinion de certaines personnes à votre égard. Votre énergie en hausse vous aspire à partager avec les autres, évitez les polémiques, gardez votre calme, un échange n\'est pas une attaque.', 'Sitôt dit, sitôt fait, vous suivez un flair infaillible. Vous allez avoir raison d\'avoir confiance en vous ce vendredi 28 septembre.', 'Ne vous attardez pas sur des soucis qui sont mineurs en fin de compte. Vous avez mieux à faire, penchez-vous sur ce qui vous apporte du plaisir.', 'Vous avez besoin de solitude pour vous plonger dans des détails pratiques, ne vous laissez pas distraire.', 'Vos réflexions évoluent aujourd\'hui dans un sens qui ne vous mène pas à valoriser vos talents, relativisez vos doutes !', 'Images/Balance.jpg'),
(8, 'Scorpion', '23 oct au 21 nov', 'Vous allez trouver de la sympathie sur votre chemin ce vendredi 28 septembre, et cela ne manquera pas de vous donner de l\'énergie. Vous aurez tout à gagner à faire davantage de mouvement, consacrez-vous à votre sport favori.', 'Un ras-le-bol vous prend par rapport à certains amis. Dire calmement ce qui ne va pas serait profitable.', 'Vous ne tiendrez pas en place, évitez de vous agiter pour peu de chose. Allez directement à l\'essentiel.', 'Vos valeurs humaines prennent le dessus sur les questions financières. Ne prenez pas de décisions importantes.', 'Ne vous entêtez pas sur des détails de pure forme, votre force aujourd\'hui se manifestera volontiers dans le travail de fond.', 'Images/Scorpion.jpg'),
(9, 'Sagittaire', '22 nov au 21 dec', 'Vous ne saurez plus par quoi commencer ce vendredi 28 septembre, vous serez assailli par mille obligations à la fois, triez. Vous allez puiser dans vos ressources pour gérer vos affaires courantes, pensez à vous évader avec vos amis et ceux qui vous sont chers.', 'Votre énergie attire à vous des personnes qui sous l\'angle amical, veulent un profit personnel dans votre lien.', 'Vos relations amicales vous seront utiles pour envisager vos amours sous un angle inédit, vous faites entrer davantage de complicité dans votre relation avec votre partenaire, les échanges sont au beau fixe.', 'Des sentiments négatifs doivent être dépassés et simplement vous servir de leçon, ne vous laissez pas envahir.', 'Freinez vos pulsions pour éviter des soucis ultérieurs et misez sur la raison.', 'Images/Sagittaire.jpg'),
(10, 'Capricorne', '22 dec au 19 jan', 'Les discussions tournent à la polémique ce vendredi 28 septembre. Ne vous laissez pas dépasser par vos émotions, prenez du recul. Vous avez besoin de souffler nerveusement parlant, coupez les ponts avec les tracas et évadez-vous !', 'Il est temps de prouver que votre point de vue est exact. Les alliances commerciales sont favorisées.', 'Vous aurez l\'élan de fond d\'aller au bout de vos idées. N\'attendez pas l\'assentiment des autres, foncez !', 'Vous avez besoin de prouver votre ambition. Ce n\'est pas le moment de prendre des décisions sérieuses, il faut planifier votre action.', 'Vous vous activerez avec assiduité, aujourd\'hui mais votre entourage ne sera pas un soutien pour vous !', 'Images/Capricorne.jpg'),
(11, 'Verseau', '20 jan au 18 fév', 'Bien dans votre peau, vous êtes en accord avec vous-même, davantage à l\'écoute de votre corps, suivez cet élan. Vous allez résoudre des questions urgentes sans perdre de temps. Votre efficacité est redoutable ce vendredi 28 septembre !', 'Vous allez avoir du mal à comprendre certains de vos collaborateurs, ne vous braquez pas avec eux pour autant.', 'Vous vivrez dans une journée bénéfique sur le plan financier. Les démarches sont hautement favorisées et prolifiques.', 'Un temps de répit s\'annonce aujourd\'hui, c\'est le moment de faire un bilan sur ces trois dernières semaines.', 'Vous frotter à certaines difficultés va vous inciter à vous dépasser positivement, aujourd\'hui, ce mouvement est bénéfique.', 'Images/Verseau.jpg'),
(12, 'Poisson', '19 fév au 20 mars', 'Vous vous sentez animé d\'une forte bienveillance envers votre entourage. Votre vie affective éclipse tout le reste. Votre vitalité est soutenue par votre moral, vous voyez la vie en rose ! Vous avez malgré tout besoin de boire davantage pour hydrater votre organisme.', 'ce vendredi 28 septembre laisse augurer une tranquille neutralité. Rien ne s\'oppose donc à ce que vous vous occupiez uniquement de vous.', 'Ne rentrez pas dans le système de ceux qui cherchent à vous faire douter de vous... Vous aurez raison d\'être têtu !', 'Vous serez très sérieux dans vos comptes aujourd\'hui, ce qui vous aidera à finaliser des détails importants.', 'Vos efforts aujourd\'hui trouvent des échos hautement favorables. Vous arriverez de plus à trouver de bons alliés.', 'Images/Poisson.jpg');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `horoscopes`
--
ALTER TABLE `horoscopes`
  ADD PRIMARY KEY (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
