<?php
require_once 'DatabaseConnecter.php';
require_once '../Entity/User.php';

class transactionAccessor
{
    private $conn = NULL;
    public function __construct()
    {
        $cm = new Connector();

        $this->conn = $cm->connect_db();
        if (is_null($this->conn)) {
            throw new Exception("no connection");
        }
    }
    public function getPermissionsOfUser($username)
    {
        
    }
}
?>