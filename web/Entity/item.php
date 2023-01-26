<?php

class Item implements JsonSerializable {
    private $itemID;
    private $name;
    private $description;
    private $category;
    private $weight;
    private $costPrice;
    private $retailPrice;
    private $supplierID;
    private $active;
    private $notes;
    private $caseSize;

    public function __construct( $itemID, $name, $description,$category,$weight,$costPrice,$retailPrice,$supplierID,$active,$notes,$caseSize) {
        $this->itemID = $itemID;
        $this->name = $name;
        $this->description = $description;
        $this->category = $category;
        $this->weight = $weight;
        $this->costPrice = $costPrice;
        $this->retailPrice = $retailPrice;
        $this->supplierID = $supplierID;
        $this->active = $active;
        $this->notes = $notes;
        $this->caseSize = $caseSize;


    }
    public function getID()
    {
        return $this->itemID;
    }
    public function getName() {
        return $this->name;
    }

    public function getQuantity() {
        return $this->description;
    }
    public function getCategory() {
        return $this->category;
    }
    public function getWeight() {
        return $this->weight;
    }
    public function getCostPrice() {
        return $this->costPrice;
    }
    
    public function getRetailPrice() {
        return $this->retailPrice;
    }
    
    public function getSupplierID() {
        return $this->supplierID;
    }
    public function getActive() {
        return $this->active;
    }
    public function getNotes() {
        return $this->notes;
    }
    public function getCaseSize() {
        return $this->caseSize;
    }
    public function jsonSerialize() {
        return get_object_vars($this);
    }
}
