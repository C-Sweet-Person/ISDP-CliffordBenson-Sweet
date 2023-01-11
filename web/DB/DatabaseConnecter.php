<?php

class Connector {

    public function connect_db() {

       $db = new PDO("mysql:host=localhost;dbname=bullseyedb2023", "root", "mysql");
        $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        return $db;
    }

}
