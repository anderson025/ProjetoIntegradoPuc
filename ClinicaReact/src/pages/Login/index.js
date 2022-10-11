import React, {useState} from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Link from '@mui/material/Link';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import { createTheme, ThemeProvider } from '@mui/material/styles';

import api from '../../services/api';
import {useNavigate} from 'react-router-dom';
import MainRoutes from '../../routes';


const theme = createTheme();

export default function SignInSide() {


    const [email, setEmail] = useState('');
     const [password, setPassword] = useState('');

     const navagate = useNavigate();

     async function Login(event){
         event.preventDefault();

        const data = {
             email, password
         };

         try {
            const response = await api.post('/api/conta/loginuser', data);
             localStorage.setItem('email', email);
             localStorage.setItem('token', response.data.token);
            localStorage.setItem('expiration', response.data.expiration);

             navagate('/home');
         } catch (error) {
             alert('O login falhou' + error);
         }
     }


  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    console.log({
      email: data.get('email'),
      password: data.get('password'),
    });
  };

  return (
    <ThemeProvider theme={theme}>
      <Grid container component="main" sx={{ height: '100vh' }}>
        <CssBaseline />
        <Grid
          item
          xs={false}
          sm={4}
          md={7}
          sx={{
            // backgroundImage: 'url(https://source.unsplash.com/random)',
            backgroundRepeat: 'no-repeat',
            backgroundColor: (t) =>
              t.palette.mode === 'light' ? t.palette.grey[50] : t.palette.grey[900],
            backgroundSize: 'cover',
            backgroundPosition: 'center',
          }}
        />
        <Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
          <Box
            sx={{
              my: 8,
              mx: 4,
              display: 'flex',
              flexDirection: 'column',
              alignItems: 'center',
            }}
          >
            <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
              <LockOutlinedIcon />
            </Avatar>
            <Typography component="h1" variant="h5">
              Sistema de clínica
            </Typography>
            <Box component="form" noValidate onSubmit={Login} sx={{ mt: 1 }}>
              <TextField
                margin="normal"
                required
                fullWidth
                id="email"
                label="Email"
                name="email"
                autoComplete="email"
                autoFocus
                value={email}
                onChange={e => setEmail(e.target.value)}


              />
              <TextField
                margin="normal"
                required
                fullWidth
                name="password"
                label="Senha"
                type="password"
                id="password"
                autoComplete="current-password"
                value={password}
                onChange={e => setPassword(e.target.value)} 
              />
              {/* <FormControlLabel
                control={<Checkbox value="remember" color="primary" />}
                label="Remember me"
              /> */}
              <Button
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
              >
                Login
              </Button>
              <Grid container>
                <Grid item xs>
                  <Link href="#" variant="body2">
                    {/* Forgot password? */}
                  </Link>
                </Grid>
                <Grid item>
                  {/* <Link href="#" variant="body2">
                    {"Don't have an account? Sign Up"}
                  </Link> */}
                </Grid>
              </Grid>
              {/* <Copyright sx={{ mt: 5 }} /> */}
            </Box>
          </Box>
        </Grid>
      </Grid>
    </ThemeProvider>
  );
}


// import './style.css';
// import api from '../../services/api';
// import React, {useState} from 'react';
// import {useNavigate} from 'react-router-dom';

// export default function Login(){

//     const [email, setEmail] = useState('');
//     const [password, setPassword] = useState('');

//     const navagate = useNavigate();

//     async function Login(event){
//         event.preventDefault();

//         const data = {
//             email, password
//         };

//         try {
//             const response = await api.post('/api/conta/loginuser', data);
//             localStorage.setItem('email', email);
//             localStorage.setItem('token', response.data.token);
//             localStorage.setItem('expiration', response.data.expiration);

//             navagate('/home');
//         } catch (error) {
//             alert('O login falhou' + error);
//         }
//     }

//     return(
//         <div className="login-container">
//            <section className="form">
                
//                 <form onSubmit={Login}>
//                     <h1>Sistema de clínica</h1>

//                     <input placeholder="Exemplo@email.com" 
//                         value={email}
//                         onChange={e => setEmail(e.target.value)}
//                     />

//                     <input type ="password" placeholder="Password"
//                         value={password}
//                         onChange={e => setPassword(e.target.value)} 
//                     />

//                     <button className="button" type="submit"> Login </button>
//                 </form>
//            </section>
//         </div>
       
//     )
// }