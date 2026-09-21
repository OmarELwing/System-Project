import 'package:flutter/material.dart';
import 'models.dart';
import 'side_navigation.dart';

class SubjectListScreen extends StatelessWidget {
  const SubjectListScreen({super.key});

  @override
  Widget build(BuildContext context) {
    final List<SubjectModel> subjects = [
      SubjectModel(
        id: '1',
        title: 'Database Systems',
        code: 'CS301',
        creditHours: 3,
        doctorName: 'Dr.Ahmed Al-Abbasi',
        schedule: 'Sun . 10:00 AM',
        room: 'Room 302',
        description: 'Database Systems and relational database concepts.',
      ),
      SubjectModel(
        id: '2',
        title: 'Data Mining',
        code: 'CS302',
        creditHours: 3,
        doctorName: 'Dr.Sara Mohamed',
        schedule: 'Mon . 12:00 PM',
        room: 'Room 201',
        description: 'Introduction to data mining techniques and data preprocessing.',
      ),
      SubjectModel(
        id: '3',
        title: 'Computer Vision',
        code: 'CS303',
        creditHours: 3,
        doctorName: 'Dr.Ali Mahmoud',
        schedule: 'Tue . 9:00 AM',
        room: 'Room 101',
        description: 'Image processing techniques and feature extraction.',
      ),
      SubjectModel(
        id: '4',
        title: 'Cloud Computing',
        code: 'CS304',
        creditHours: 3,
        doctorName: 'Dr.Fatma Ahmed',
        schedule: 'Wed . 2:00 PM',
        room: 'Room 203',
        description: 'Fundamentals of cloud architectures and virtualization.',
      ),
      SubjectModel(
        id: '5',
        title: 'Compiler Design',
        code: 'CS305',
        creditHours: 3,
        doctorName: 'Dr.Yara Ibrahim',
        schedule: 'Sun . 1:00 PM',
        room: 'Lab 3',
        description: 'Lexical analysis, parsing, semantic analysis, and optimizations.',
      ),
    ];

    return Scaffold(
      drawer: const AppDrawer(),
      appBar: AppBar(
        leading: Builder(
          builder: (context) => IconButton(
            icon: const Icon(Icons.arrow_back, color: Color(0xFF1E4630)),
            onPressed: () {
              if (Navigator.canPop(context)) {
                Navigator.pop(context);
              } else {
                Scaffold.of(context).openDrawer();
              }
            },
          ),
        ),
        title: const Text('My Subjects', style: TextStyle(color: Color(0xFF1E4630), fontWeight: FontWeight.bold)),
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: ListView.separated(
        padding: const EdgeInsets.all(16),
        itemCount: subjects.length,
        separatorBuilder: (_, __) => const SizedBox(height: 12),
        itemBuilder: (context, index) {
          final item = subjects[index];
          return InkWell(
            onTap: () => Navigator.pushNamed(context, '/subject-details', arguments: item),
            child: Container(
              padding: const EdgeInsets.all(16),
              decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16)),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    children: [
                      const CircleAvatar(backgroundColor: Color(0xFFE8F5E9), child: Icon(Icons.menu_book, color: Color(0xFF1E4630))),
                      const SizedBox(width: 12),
                      Expanded(
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Text(item.title, style: const TextStyle(fontWeight: FontWeight.bold)),
                            Text(item.code, style: const TextStyle(color: Colors.grey, fontSize: 12)),
                          ],
                        ),
                      ),
                      Text('${item.creditHours} Credit Hours', style: const TextStyle(fontSize: 12, fontWeight: FontWeight.bold)),
                    ],
                  ),
                  const Divider(height: 20),
                  Row(
                    children: [
                      Text(item.doctorName, style: const TextStyle(color: Colors.grey, fontSize: 11)),
                      const Spacer(),
                      Text('${item.schedule} | ${item.room}', style: const TextStyle(color: Colors.grey, fontSize: 11)),
                    ],
                  )
                ],
              ),
            ),
          );
        },
      ),
    );
  }
}