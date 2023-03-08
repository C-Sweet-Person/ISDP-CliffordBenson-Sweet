<?php

class inventoryStore implements JsonSerializable {

private $itemID;
private $itemName;
private $category;
private $siteID;
private $quantity;
private $itemLocation;
private $reorderThreshold;
private $retailCost;
public function __construct($itemID,$itemName,$category,$siteID,$quantity,$itemLocation,$reorderThreshold,$retailCost)
{
    $this->itemID = $itemID;
    $this->itemName = $itemName;
    $this->category = $category;
    $this->siteID = $siteID;
    $this->quantity = $quantity;
    $this->itemLocation = $itemLocation;
    $this->reorderThreshold = $reorderThreshold;
    $this->retailCost = $retailCost;
}
public function getID()
{
    return $this->itemID;
}
public function getName()
{
    return $this->itemName;
}
public function getCategory()
{
    return $this->category;
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
public function getRetailCost()
{
    return $this->retailCost;
}
public function jsonSerialize() {
    return get_object_vars($this);
}
}