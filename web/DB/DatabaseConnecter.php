<?php

class Connector {

    public function connect_db() {
        $dsn = 'mysql:dbname=bullseyedb2023;host=127.0.0.1;port:3306';
        $user = 'root';
        $pass = 'mysql';
       $db = new PDO($dsn,$user,$pass);
        $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        return $db;
    }

}
