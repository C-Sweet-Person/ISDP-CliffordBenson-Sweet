<?php

class inventory implements JsonSerializable {

private $itemID;
private $siteID;
private $quantity;
private $itemLocation;
private $reorderThreshold;

public function __construct($itemID,$siteID,$quantity,$itemLocation,$reorderThreshold)
{
    $this->itemID = $itemID;
    $this->siteID = $siteID;
    $this->quantity = $quantity;
    $this->itemLocation = $itemLocation;
    $this->$reorderThreshold = $reorderThreshold;
}
public function getID()
{
    return $this->itemID;
}
public function getSiteID()
{
    return $this->siteID;
}
public function getQuantity()
{
    return $this->quantity;
}
public function getItemLocation()
{
    return $this->itemLocation;
}
public function getReorderThreshold()
{
    return $this->reorderThreshold;
}
public function jsonSerialize() {
    return get_object_vars($this);
}
}