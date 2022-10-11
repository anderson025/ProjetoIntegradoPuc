import { Box, CssBaseline, IconButton, Toolbar, Typography } from "@mui/material";
import React from "react";
import MenuIcon from '@mui/icons-material/Menu';
import MuiAppBar from '@mui/material/AppBar';
import MuiDrawer from '@mui/material/Drawer';
import {Link , useParams, useNavigate, useEffect} from "react-router-dom";
import { styled, useTheme } from '@mui/material/styles';
import List from '@mui/material/List';
import Divider from '@mui/material/Divider';

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



export default function DrawerComponent(){

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

    return(

        <>
        <CssBaseline />
        <Drawer position="fixed" variant="permanent" open={open}>
        <DrawerHeader>
          <IconButton onClick={handleDrawerClose}>
            {theme.direction === 'rtl' ? <ChevronRightIcon /> : <ChevronLeftIcon />}
          </IconButton>
        </DrawerHeader>
        <Divider />
        <List>
          {['Agenda', 'Pacientes', 'Funcionarios', 'Avaliações'].map((text, index) => (
            
           
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
                    {text === 'Avaliações' ? <LoopIcon /> : null}
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

      
      </>
    )
}