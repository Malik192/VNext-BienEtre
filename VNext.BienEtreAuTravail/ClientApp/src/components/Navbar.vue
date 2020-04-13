<template>
<div class="app">
    <v-app-bar app color="#4d8c05" dark>
      <v-toolbar-title>
          <v-img class="mr-5" src="@/assets/logo-m.png" width="150px"></v-img>

      </v-toolbar-title>
      <v-spacer></v-spacer>
      
      <v-toolbar-side-icon   v-if="Isconnected">
        <v-tooltip bottom>
          <template v-slot:activator="{ on }">
            <v-img class="mr-5" src="@/assets/logo.png" width="50px" v-on="on" @click="logout"></v-img>
          </template>
          <span>Deconnexion</span>
        </v-tooltip>
      </v-toolbar-side-icon>
        
    </v-app-bar>
 </div>
</template>
<script src="./Navbar.ts"  lang="ts">
</script>
