<?php

class transaction implements JsonSerializable {
    private $txnID;
    private $siteIDTo;
    private $siteIDFrom;
    private $status;
    private $shipDate;
    private $txnType;
    private $barCode;
    private $createdDate;
    private $DeliveryID;
    private $emergencyDelivery;

    public function __construct( $txnID,$siteIDTo, $siteIDFrom, $status,$shipDate,$txnType,$barCode,$createdDate,$DeliveryID,$emergencyDelivery) {
        $this->txnID = $txnID;
        $this->siteIDTo = $siteIDTo;
        $this->siteIDFrom = $siteIDFrom;
        $this->status = $status;
        $this->shipDate = $shipDate;
        $this->txnType = $txnType;
        $this->barCode = $barCode;
        $this->createdDate = $createdDate;
        $this->DeliveryID = $DeliveryID;
        $this->emergencyDelivery = $emergencyDelivery;
    }
    public function getID()
    {
        return $this->txnID;
    }
    public function getSiteIDTo() {
        return $this->siteIDTo;
    }

    public function getSiteIDFrom() {
        return $this->siteIDFrom;
    }
    public function getStatus() {
        return $this->status;
    }
    public function getShipDate() {
        return $this->shipDate;
    }
    public function getType() {
        return $this->txnType;
    }
    
    public function getBarCode() {
        return $this->barCode;
    }
    
    public function getCreatedDate() {
        return $this->createdDate;
    }
    public function getDeliveryID() {
        return $this->DeliveryID;
    }
    public function isEmergencyOrder() {
        return $this->emergencyDelivery;
    }
    public function jsonSerialize() {
        return get_object_vars($this);
    }
}
