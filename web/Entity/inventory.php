<?php

class inventory implements JsonSerializable {

private $itemID;
private $itemName;
private $siteID;
private $quantity;
private $itemLocation;
private $reorderThreshold;

public function __construct($itemID,$itemName,$siteID,$quantity,$itemLocation,$reorderThreshold)
{
    $this->itemID = $itemID;
    $this->itemName = $itemName;
    $this->siteID = $siteID;
    $this->quantity = $quantity;
    $this->itemLocation = $itemLocation;
    $this->reorderThreshold = $reorderThreshold;
}
public function getID()
{
    return $this->itemID;
}
public function getName()
{
    return $this->itemName;
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