// Import the functions you need from the SDKs you need
import { initializeApp } from "https://www.gstatic.com/firebasejs/10.7.0/firebase-app.js";
import { getAnalytics } from "https://www.gstatic.com/firebasejs/10.7.0/firebase-analytics.js";
import { getDatabase } from 'https://www.gstatic.com/firebasejs/10.7.0/firebase-database.js'
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
    apiKey: "AIzaSyChuuZu6j2NOmlOBjfxIani9_LNhxrirOM",
    authDomain: "hallrentalproject.firebaseapp.com",
    databaseURL: "https://hallrentalproject-default-rtdb.europe-west1.firebasedatabase.app",
    projectId: "hallrentalproject",
    storageBucket: "hallrentalproject.appspot.com",
    messagingSenderId: "485950336004",
    appId: "1:485950336004:web:f74a8c8a54871171031951",
    measurementId: "G-CXG7RKV9SP"
};

// Initialize Firebase
export const app = initializeApp(firebaseConfig);
export const database = getDatabase(app);