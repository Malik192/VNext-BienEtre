<template>
  <v-container>
    <v-content>
      <p
        class="font-weight-black text-center text"
        color="#B2D3A3"
      >Quelle est votre humeur du jour ?</p>
    </v-content>
    <v-spacer></v-spacer>
    <v-content class="float-sm-left">
      <v-layout justify-center>
        <v-card elevation="0">
          <v-row justify="space-around">
            <v-col cols="4" sm="4">
              <v-img class="float-sm-left" src="@/assets/004-smile.png"></v-img>
            </v-col>
            <v-col cols="4" sm="4">
              <v-img class="float-sm-left" src="@/assets/013-meh.png"></v-img>
            </v-col>
            <v-col cols="4" sm="4">
              <v-img class="float-sm-left" src="@/assets/009-sad-1.png"></v-img>
            </v-col>
          </v-row>
        </v-card>
      </v-layout>
    </v-content>
  </v-container>
</template>
<style>
.text {
  color: #4d8c05;
}
</style>