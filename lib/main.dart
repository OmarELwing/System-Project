import 'package:flutter/material.dart';

import 'student_main_shell.dart';
import 'SubjectListScreen.dart';
import 'subject_details_screen.dart';
import 'weekly_schedule_screen.dart';
import 'attendance_screen.dart';
import 'assessment_screen.dart';
import 'performance_screen.dart';
import 'models.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'School App',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        scaffoldBackgroundColor: const Color(0xFFF7F9F8),
        primaryColor: const Color(0xFF1E4630),
      ),
      initialRoute: '/',
      routes: {
        '/': (context) => const StudentMainShell(),
        '/subjects': (context) => const SubjectListScreen(),
        '/schedule': (context) => const WeeklyScheduleScreen(),
        '/attendance': (context) => const AttendanceScreen(),
        '/assessments': (context) => const AssessmentScreen(),
        '/performance': (context) => const PerformanceScreen(),
      },
      onGenerateRoute: (settings) {
        if (settings.name == '/subject-details') {
          final subject = settings.arguments as SubjectModel?;
          return MaterialPageRoute(
            builder: (context) => SubjectDetailsScreen(subject: subject),
          );
        }
        return null;
      },
    );
  }
}