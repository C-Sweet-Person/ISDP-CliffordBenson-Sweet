<?php

class vehicle implements JsonSerializable {
    private $vehicleType;
    private $maxWeight;
    private $HourlyTruckCost;
    private $costPerKm;
    private $notes;

    public function __construct( $vehicleType,$maxWeight, $HourlyTruckCost, $costPerKm,$notes){
        $this->vehicleType = $vehicleType;
        $this->maxWeight = $maxWeight;
        $this->HourlyTruckCost = $HourlyTruckCost;
        $this->costPerKm = $costPerKm;
        $this->notes = $notes;
    }
    public function getType()
    {
        return $this->vehicleType;
    }
    public function getMaxWeight() {
        return $this->maxWeight;
    }

    public function getHourlyTruckCost() {
        return $this->HourlyTruckCost;
    }
    public function getCostPerKm() {
        return $this->costPerKm;
    }

    public function getNotes()
    {
        return $this->notes;
    }
 
    public function jsonSerialize() {
        return get_object_vars($this);
    }
}
