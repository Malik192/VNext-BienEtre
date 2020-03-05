<template>
  <v-container>
    
    <v-content>
           <h2
        class="font-weight-black text-center text"
        color="#B2D3A3"
      >Selectionnez la citation qui vous parle le plus</h2>
      <v-layout justify-center>
        <v-card elevation="0">
            <v-container
        fluid
        grid-list-lg
      >
        <v-layout row wrap>
          <v-flex xs12>
            <v-card id="citation1"   color="#B2D3A3" class="white--text">
              <v-card-title primary-title >
                <div>
                  <span class="caption">"Ce n'est pas par des paroles que s'engagent les décisions, mais seulement par le travail. "</span>
                </div>
              </v-card-title>
    
            </v-card>
               </v-flex>
                <v-flex xs12>
             <v-card id="citation2"  color="#B2D3A3" class="white--text">
              <v-card-title primary-title>
                <div>
                 
                  <span class="caption" >"Que ton ambition soit de voir, non pas ce que tu pourras tirer du travail, mais ce que tu pourras y mettre de toi."</span>
                </div>
              </v-card-title>
            
            </v-card>
                </v-flex>
             <v-flex xs12>
             <v-card id="citation3"   color="#B2D3A3" class="white--text">
              <v-card-title primary-title>
                <div>
                 
                  <span class="caption">" Lorsque deux ou plusieurs personnes joignent leurs efforts dans un esprit d'harmonie et travaillent à la réalisation d'un objectif. "</span>
                </div>
              </v-card-title>
            
            </v-card>
             </v-flex>
               <v-flex xs12>
             <v-card   class="white--text" elevation="0">
              <v-card-title primary-title>
                  <v-textarea
         v-model="text"
        class="form-control"
        :maxlength="max"
        auto-grow
  
        color="#4d8c05"
        label="Avis"
      
        prepend-inner-icon="speaker_notes"
         counter=140
        rows="1"
      ></v-textarea>
         <div class="input-group-addon" v-text="(max - text.length)"></div>
  
              </v-card-title>
             </v-card>
               </v-flex>
                    <v-flex xs12>
                      <div class="form-group">
  
  </div>
             <v-card   elevation="0">
           <v-card-actions class="justify-center">
  <v-btn color="#4d8c05" class="white--text">
    valider
  </v-btn>
</v-card-actions>
             </v-card>
                    </v-flex>
        </v-layout>
            </v-container>
        </v-card>
      </v-layout>
    </v-content>
  </v-container>
</template>
<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
  data: () => ({
          max: 140,
    text: "",
           
        
     }),
})
</script>
<style>
.text {
  color: #4d8c05;
}
.v-card__text, .v-card__title {
  word-break: normal; /* maybe !important  */
}
.formfield * {
  vertical-align: middle;
}
</style>