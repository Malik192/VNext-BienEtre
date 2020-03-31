<template>
  <v-container>
    <v-content> 
      <p
        class="font-weight-black text-center text"
        color="#B2D3A3"
      >Quelle est ton humeur du jour ?</p>
    </v-content>
    <v-spacer></v-spacer>
    <v-content>
      <v-layout justify-center>
        <v-card elevation="0">
          <v-row align="center">
            <v-col cols="4" sm="4" lg="4">
           <router-link to="/Quotes">
                <v-img class="float-sm-left" src="@/assets/004-smile.png" style="width:250px"  ></v-img>
           </router-link>
            </v-col>

            <v-col cols="4" sm="4" xs="4">
              <router-link to="/Quotes">
                <v-img class="float-sm-left" src="@/assets/013-meh.png" style="width:250px"></v-img>
              </router-link>
            </v-col>
            <v-col cols="4" sm="4">
              <router-link to="/Quotes">
                <v-img class="float-sm-left" src="@/assets/009-sad-1.png" style="width:250px"></v-img>
              </router-link>
            </v-col>
          </v-row>
        </v-card>
      </v-layout>
    </v-content>
 <v-snackbar v-model="snackbar">
            {{ text }}
            <v-btn color="#1DB954" text @click="snackbar = false">
              <v-icon medium right>cancel</v-icon>
            </v-btn>
          </v-snackbar>   
  </v-container>

</template>
<style>
.text {
  color: #4d8c05;
}
</style>
<script src='./Mood.ts'   lang="ts">
</script>
