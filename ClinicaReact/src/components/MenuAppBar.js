import * as React from 'react';
import { styled, useTheme } from '@mui/material/styles';
import Box from '@mui/material/Box';
import MuiDrawer from '@mui/material/Drawer';
import MuiAppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import CssBaseline from '@mui/material/CssBaseline';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import InboxIcon from '@mui/icons-material/MoveToInbox';
import MailIcon from '@mui/icons-material/Mail';
import AlarmIcon from '@mui/icons-material/Alarm';
import AccessibilityIcon from '@mui/icons-material/Accessibility';
import AssignmentIndIcon from '@mui/icons-material/AssignmentInd';
import LoopIcon from '@mui/icons-material/Loop';
import LogoutIcon from '@mui/icons-material/Logout';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import {Link , useParams, useNavigate, useEffect} from "react-router-dom";
import MainRoutes from '../routes';
import Funcionarios from '../pages/Funcionarios';
import NovoFuncionario from '../pages/NovoFuncionario';
import { Button } from 'bootstrap';
import Home from '../pages/Home';


const drawerWidth = 240;

const openedMixin = (theme) => ({
  width: drawerWidth,
  transition: theme.transitions.create('width', {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.enteringScreen,
  }),
  overflowX: 'hidden',
});

const closedMixin = (theme) => ({
  transition: theme.transitions.create('width', {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  overflowX: 'hidden',
  width: `calc(${theme.spacing(7)} + 1px)`,
  [theme.breakpoints.up('sm')]: {
    width: `calc(${theme.spacing(8)} + 1px)`,
  },
});

const DrawerHeader = styled('div')(({ theme }) => ({
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'flex-end',
  padding: theme.spacing(0, 1),
  // necessary for content to be below app bar
  ...theme.mixins.toolbar,
}));

const AppBar = styled(MuiAppBar, {
  shouldForwardProp: (prop) => prop !== 'open',
})(({ theme, open }) => ({
  zIndex: theme.zIndex.drawer + 1,
  transition: theme.transitions.create(['width', 'margin'], {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  ...(open && {
    marginLeft: drawerWidth,
    width: `calc(100% - ${drawerWidth}px)`,
    transition: theme.transitions.create(['width', 'margin'], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  }),
}));

const Drawer = styled(MuiDrawer, { shouldForwardProp: (prop) => prop !== 'open' })(
  ({ theme, open }) => ({
    width: drawerWidth,
    flexShrink: 0,
    whiteSpace: 'nowrap',
    boxSizing: 'border-box',
    ...(open && {
      ...openedMixin(theme),
      '& .MuiDrawer-paper': openedMixin(theme),
    }),
    ...(!open && {
      ...closedMixin(theme),
      '& .MuiDrawer-paper': closedMixin(theme),
    }),
  }),
);



export default function MenuAppBar(){

  const theme = useTheme();
  const [open, setOpen] = React.useState(false);
  const navigate = useNavigate();

  const email = localStorage.getItem('email');
  const {funcionarioId} = useParams();

  const url_atual = window.location.href;
  

  const handleDrawerOpen = () => {
    setOpen(true);
  };

  const handleDrawerClose = () => {
    setOpen(false);
  };
  
  async function logout(){
    try {
        localStorage.clear();
        localStorage.setItem('token', '');
        
        navigate('/');
    } catch (error) {
        alert('Não foi possível realizar logout' + error);
    }
  }

  return (

    <Box sx={{ display: 'flex' }}>
      <CssBaseline />
      <AppBar position="fixed" open={open}>
        <Toolbar>
          <IconButton
            color="inherit"
            aria-label="open drawer"
            onClick={handleDrawerOpen}
            edge="start"
            sx={{
              marginRight: 5,
              ...(open && { display: 'none' }),
            }}
          >
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" noWrap component="div">
            Sistema de Clínica
          </Typography>
        </Toolbar>
      </AppBar>

      
      <Drawer variant="permanent" open={open}>
        <DrawerHeader>
          <IconButton onClick={handleDrawerClose}>
            {theme.direction === 'rtl' ? <ChevronRightIcon /> : <ChevronLeftIcon />}
          </IconButton>
        </DrawerHeader>
        <Divider />
        <List>
          {['Agenda', 'Pacientes', 'Funcionarios', 'Avaliacao'].map((text, index) => (
            
           
            <ListItem key={text} disablePadding sx={{ display: 'block' }}
                onClick={() => navigate('/'+text)}
                // {text === 'Funcionarios'? null : null }
            >
               
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
                // component={Link} to='/funcionarios'
                   
                
               
                
              >
                
                
                <ListItemIcon
                  sx={{
                    minWidth: 0,
                    mr: open ? 3 : 'auto',
                    justifyContent: 'center',
                  }}
                >
                    {text === 'Agenda' ? <AlarmIcon /> : null}  
                    {text === 'Pacientes' ? <AccessibilityIcon /> : null}  
                    {text === 'Funcionarios' ? <AssignmentIndIcon /> : null} 
                    {text === 'Avaliacao' ? <LoopIcon /> : null}
                  {/* {index % 2 === 0 ? <AlarmIcon /> : <MailIcon />} */}
                </ListItemIcon>
                <ListItemText primary={text} sx={{ opacity: open ? 1 : 0 }} />                
              </ListItemButton>              
            </ListItem>
           
          ))}
        </List>
        <Divider />
        <List>
          {['Perfil', 'Sair'].map((text, index) => (
            <ListItem key={text} disablePadding sx={{ display: 'block' }}
                onClick={text === 'Sair'? logout: null}
            >
              <ListItemButton
                sx={{
                  minHeight: 48,
                  justifyContent: open ? 'initial' : 'center',
                  px: 2.5,
                }}
              >
                <ListItemIcon
                  sx={{
                    minWidth: 0,
                    mr: open ? 3 : 'auto',
                    justifyContent: 'center',
                  }}
                >
                    
                   {text === 'Perfil' ? <AccountCircleIcon /> : null} 
                   {text === 'Sair' ? <LogoutIcon /> : null} 
                  {/* {index % 2 === 0 ? <InboxIcon /> : <MailIcon />} */}
                </ListItemIcon>
                <ListItemText primary={text} sx={{ opacity: open ? 1 : 0 }} />
              </ListItemButton>
            </ListItem>
          ))}
        </List>
      </Drawer>
      {/* <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
        <DrawerHeader />
        <Typography paragraph>
        {/* <header> */}
                {/* <span>Bem vindo, <strong>{email}</strong>!</span>               */}
                
        {/* </header> */}
        {/* </Typography>
        <Typography paragraph> */}

                  
            
            {/* {console.log(url_atual)} */}
            {/* {url_atual === 'http://localhost:3000/Funcionarios'? <Funcionarios/> : <Home/>}  */}
            
            {/* {url_atual === 'localhost:3000/home' ? <Home/> : null} */}
           
            {/* {url_atual === "http://localhost:3000/home" ? <Home/> : null}
            {url_atual === "http://localhost:3000/Funcionarios" ? <Funcionarios/> : null}             */}
            {/* <section className='body-aplication'>                
            {url_atual === "http://localhost:3000/home" ? <Home/> : null}    
                
                
            </section> */}
            
        {/* </Typography>
      </Box> */} 
    </Box>
  )
}
