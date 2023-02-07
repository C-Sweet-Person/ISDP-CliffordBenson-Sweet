<?php

class delivery implements JsonSerializable {
    private $DeliveryID;
    private $distanceCost;
    private $vehicleType;
    private $notes;

    public function __construct( $DeliveryID,$distanceCost, $vehicleType, $notes){
        $this->DeliveryID = $DeliveryID;
        $this->distanceCost = $distanceCost;
        $this->vehicleType = $vehicleType;
        $this->notes = $notes;
    }
    public function getID()
    {
        return $this->DeliveryID;
    }
    public function getDistanceCost() {
        return $this->distanceCost;
    }

    public function getVehicleType() {
        return $this->vehicleType;
    }
    public function getNotes() {
        return $this->notes;
    }
 
    public function jsonSerialize() {
        return get_object_vars($this);
    }
}
