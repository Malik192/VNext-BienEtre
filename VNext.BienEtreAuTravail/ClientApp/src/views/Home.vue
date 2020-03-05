<template>
  <div class="home">
    <div class="banner">
      
    </div>
    <div class="container page">
      <div class="row">
         <v-row justify="center">
  </v-row>

          <SignIn></SignIn>
        <router-view></router-view>
      </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src 
import SignIn from '@/views/SignIn.vue' 

export default {
  name: "home",
  components: {
    SignIn, 
  
  }
};
</script>
