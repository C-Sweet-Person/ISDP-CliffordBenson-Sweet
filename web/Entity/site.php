<?php

class site implements JsonSerializable {

    private $siteID;
    private $name;
    private $provinceID;
    private $address;
    private $address2;
    private $city;
    private $country;
    private $postalCode;
    private $phone;
    private $dayOfWeek;
    private $distanceFromWH;
    private $siteType;
    private $notes;
    private $active;
    public function __construct($ID,$name,$provinceID,$address,$address2,$city,$country,$postalCode,$phone,$dayOfWeek,$distanceFromWH,$siteType,$notes,$active)
    {
        $this->siteID = $ID;
        $this->name = $name;
        $this->provinceID = $provinceID;
        $this->address = $address;
        $this->address2 = $address2;
        $this->city = $city;
        $this->country = $country;
        $this->postalCode = $postalCode;
        $this->phone = $phone;
        $this->dayOfWeek = $dayOfWeek;
        $this->distanceFromWH = $distanceFromWH;
        $this->siteType = $siteType;
        $this->notes = $notes;
        $this->active = $active;
    }
    public function getID()
    {
        return $this->siteID;
    }
    public function getName()
    {
      return $this->name;  
    }
    public function getProvinceID()
    {
      return $this->provinceID;  
    }

    public function getAddress()
    {
    return $this->address;
    }
    public function getAddress2()
    {
    return $this->address2;
    }
    public function getCity()
    {
        return $this->city;
    }
    public function getCountry()
    {
        return $this->country;
    }
    public function getPostalCode()
    {
        return $this->postalCode;
    }
    public function getPhone()
    {
        return $this->phone;
    }
    public function getDayOfWeek()
    {
        return $this->dayOfWeek;
    }
    public function getDistanceFromWH()
    {
        return $this->distanceFromWH;
    }
    public function getSiteType()
    {
        return $this->siteType;
    }
    public function getNotes()
    {
        return $this->notes;
    }
    public function getActive()
    {
        return $this->active;
    }


    public function jsonSerialize() {
        return get_object_vars($this);
    }
}