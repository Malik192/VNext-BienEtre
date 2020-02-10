<template>
 
        <v-app id="app">
<link href="https://fonts.googleapis.com/css?family=Material+Icons" rel="stylesheet">

        
            <v-content>
              <Navbar></Navbar>
            
                <Quotes></Quotes>
            </v-content>

        </v-app>
      
</template>

<script lang="ts">
import Vue from 'vue';
import HelloWorld from './components/HelloWorld.vue';
import Auth from './components/Auth.vue';
import Navbar from './components/Navbar.vue';
import Mood from './components/Mood.vue';
import Quotes from './components/Quotes.vue';



export default Vue.extend({
  name: 'App',

  components: {
      HelloWorld,
      Auth,
      Navbar,
      Mood,
      Quotes,
  },

  data: () => ({
    //
  }),
});
</script>

