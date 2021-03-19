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
     
        //1. Fire-Type
        new Type('Fire', 'Bug-Steel-Fire-Grass-Ice-Fairy', 'Ground-Rock-Water', ''),

        //2. Water-Type
        new Type('Water', 'Steel-Fire-Water-Ice', 'Grass-Electric', ''),    

        //3. Grass-Type
        new Type('Grass', 'Ground-Water-Grass-Electric', 'Flying-Poison-Bug-Fire-Ice', ''),  
        
        //4. Electric-Type
        new Type('Electric', 'Flying-Steel-Electric', 'Ground', ''), 

        //5. Normal-Type
        new Type('Normal', '', 'Fighting', 'Ghost'),   

        //6. Fighting-Type
        new Type('Fighting', 'Rock-Bug-Dark', 'Flying-Psychic-Fairy', ''), 

        //7. Flying-Type
        new Type('Flying', 'Fighting-Bug-Grass', 'Rock-Electric-Ice', 'Ground'),   

        //8. Poison-Type
        new Type('Poison', 'Fighting-Poison-Bug-Grass-Fairy', 'Ground-Psychic', ''), 
        
        //9. Ground-Type
        new Type('Ground', 'Poison-Rock', 'Water-Grass-Ice', 'Electric'),   

        //10. Rock-Type
        new Type('Rock', 'Normal-Flying-Poison-Fire', 'Fighting-Ground-Steel-Water-Grass', ''),
        
        //11. Bug-Type
        new Type('Bug', 'Fighting-Ground-Grass', 'Flying-Rock-Fire', ''), 
        
        //12. Ghost-Type
        new Type('Ghost', 'Poison-Bug', 'Ghost-Dark', 'Normal-Fighting'), 
        
        //13. Steel-Type
        new Type('Steel', 'Normal-Flying-Rock-Bug-Steel-Grass-Psychic-Ice-Dragon-Fairy', 'Fighting-Ground-Fire', 'Poison'),    
        
        //14. Psychic-Type
        new Type('Psychic', 'Fighting-Psychic', 'Bug-Ghost-Dark', ''), 

        //15. Ice-Type 
        new Type('Ice', 'Ice', 'Fighting-Rock-Steel-Fire', ''),   
        
        //16. Dragon-Type
        new Type('Dragon', 'Fire-Water-Grass-Electric', 'Ice-Dragon-Fairy', ''), 
        
        //17. Dark-Type
        new Type('Dark', 'Ghost-Dark', 'Fighting-Bug-Fairy', 'Psychic'),
        
        //18. Fairy-Type
        new Type('Fairy', 'Fighting-Bug-Dark', 'Poison-Steel', 'Dragon')     
    );