<?php

class User implements JsonSerializable {
    private $employeeID;
    private $username;
    private $password;
    private $firstname;
    private $lastName;
    private $email;
    private $active;
    private $locked;
    private $positionID;
    private $siteID;

    public function __construct( $employeeID, $username, $password, $firstname,$lastname,$email,$active,$locked,$positionID,$siteID) {
        $this->employeeID = $employeeID;
        $this->username = $username;
        $this->password = $password;
        $this->firstname = $firstname;
        $this->lastName = $lastname;
        $this->email = $email;
        $this->active = $active;
        $this->locked = $locked;
        $this->positionID = $positionID;
        $this->siteID = $siteID;
    }
    public function getID()
    {
        return $this->employeeID;
    }
    public function getUsername() {
        return $this->username;
    }

    public function getPassword() {
        return $this->password;
    }
    public function getFirstName() {
        return $this->firstname;
    }
    public function getLastName() {
        return $this->lastName;
    }
    public function getEmail() {
        return $this->email;
    }
    public function getActive() {
        return $this->active;
    }
    public function getLocked() {
        return $this->locked;
    }
    public function getPositionID() {
        return $this->positionID;
    }
    public function getSiteID() {
        return $this->siteID;
    }

    public function jsonSerialize() {
        return get_object_vars($this);
    }
}
