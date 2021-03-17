<?php
    class Type{
        public $name;
        public $strengths;
        public $weaknesses;
        public $resistances;

        public function __construct($name, $strengths, $weaknesses, $resistances){
            $this->name = $name;
            $this->strengths = $strengths;
            $this->weaknesses = $weaknesses;
            $this->resistances = $resistances;
        }

        public function __toString(){
            return json_encode($this);
        }

        public function isWeakness($name){
            $return = strpos($this->weaknesses, $name) || $this->weaknesses == $name;
            return $return == false ? 0 : 1;
        }

        public function isStrength($name){
            $return = strpos($this->strengths, $name) || $this->strengths == $name;
            return $return == false ? 0 : 1;
        }

        public function isRessistant($name){
            $return = strpos($this->resistances, $name) || $this->resistances == $name;
            return $return == false ? 0 : 1;
        }
    }

    $Types = [];

    array_push($Types,
     
        //Fire-Type
        new Type('Fire', 'Bug-Steel-Fire-Grass-Ice-Fairy', 'Ground-Rock-Water', ''),

        //Water-Type
        new Type('Water', 'Steel-Fire-Water-Ice', 'Grass-Electric', ''),    

        //Grass-Type
        new Type('Grass', 'Ground-Water-Grass-Electric', 'Flying-Poison-Bug-Fire-Ice', ''),  
        
        //Electric-Type
        new Type('Electric', 'Flying-Steel-Electric', 'Ground', ''), 

        //Normal-Type
        new Type('Normal', '', 'Fighting', 'Ghost'),   

        //Fighting-Type
        new Type('Fighting', 'Rock-Bug-Dark', 'Flying-Psychic-Fairy', ''), 

        //Flying-Type
        new Type('Flying', 'Fighting-Bug-Grass', 'Rock-Electric-Ice', 'Ground'),   

        //Poison-Type
        new Type('Poison', 'Fighting-Poison-Bug-Grass-Fairy', 'Ground-Psychic', ''), 
        
        //Ground-Type
        new Type('Ground', 'Poison-Rock', 'Water-Grass-Ice', 'Electric'),   

        //Rock-Type
        new Type('Rock', 'Normal-Flying-Poison-Fire', 'Fighting-Ground-Steel-Water-Grass', ''),
        
        //Bug-Type
        new Type('Bug', 'Fighting-Ground-Grass', 'Flying-Rock-Fire', ''), 
        
        //Ghost-Type
        new Type('Ghost', 'Poison-Bug', 'Ghost-Dark', 'Normal-Fighting'), 
        
        //Steel-Type
        new Type('Steel', 'Normal-Flying-Rock-Bug-Steel-Grass-Psychic-Ice-Dragon-Fairy', 'Fighting-Ground-Fire', 'Poison'),    
        
        //Psychic-Type
        new Type('Psychic', 'Fighting-Psychic', 'Bug-Ghost-Dark', ''), 

        //Ice-Type 
        new Type('Ice', 'Ice', 'Fighting-Rock-Steel-Fire', ''),   
        
        //Dragon-Type
        new Type('Dragon', 'Fire-Water-Grass-Electric', 'Ice-Dragon-Fairy', ''), 
        
        //Dark-Type
        new Type('Dark', 'Ghost-Dark', 'Fighting-Bug-Fairy', 'Psychic'),
        
        //Fairy-Type
        new Type('Fairy', 'Fighting-Bug-Dark', 'Poison-Steel', 'Dragon')     
    );