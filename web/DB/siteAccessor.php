<?php
require_once 'DatabaseConnecter.php';
require_once '../Entity/site.php';

class siteAcessor
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
    // $this->siteID = $ID;
    // $this->name = $name;
    // $this->provinceID = $provinceID;
    // $this->address = $address;
    // $this->address2 = $address2;
    // $this->city = $city;
    // $this->country = $country;
    // $this->postalCode = $postalCode;
    // $this->phone = $phone;
    // $this->dayOfWeek = $dayOfWeek;
    // $this->distanceFromWH = $distanceFromWH;
    // $this->siteType = $siteType;
    // $this->notes = $notes;
    // $this->active = $active;
    public function getAllSites()
    {
        $result = [];
        try {
            $stmt = $this->conn->prepare("select * from site");
            $stmt->execute();
            $dbresults = $stmt->fetchAll(PDO::FETCH_ASSOC);
            foreach ($dbresults as $r)
            {
                $id = $r['siteID'];
                $name = $r['name'];
                $provinceID = $r['provinceID'];
                $address = $r['address'];
                $address2 = $r['address2'];
                $city = $r['city'];
                $country = $r['country'];
                $postalCode = $r['postalCode'];
                $phone = $r['phone'];
                $dayOfWeek = $r['dayOfWeek'];
                $distanceFromWH = $r['distanceFromWH'];
                $siteType = $r['siteType'];
                $notes = $r['notes'];
                $active = $r['active'];
                $site = new site($id,$name,$provinceID,$address,$address2,$city,$country,$postalCode,$phone,
                $dayOfWeek,$distanceFromWH,$siteType,$notes,$active);
                array_push($result,$site);
            }
        }
         catch (PDOException $e) {
            $result = $e->getMessage();
        }
        finally {
            if (!is_null($stmt)) {
                $stmt->closeCursor();
            }
        }
        return $result;
    }
}
?>